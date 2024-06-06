package eu.petsontrail.tracker.ui.pets

import android.os.Build
import android.os.Bundle
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.AdapterView
import androidx.annotation.RequiresApi
import androidx.core.os.bundleOf
import androidx.navigation.fragment.findNavController
import androidx.room.ColumnInfo
import androidx.room.PrimaryKey
import eu.petsontrail.tracker.Constants
import eu.petsontrail.tracker.R
import eu.petsontrail.tracker.databinding.FragmentMyPetsBinding
import eu.petsontrail.tracker.db.AppDatabase
import eu.petsontrail.tracker.db.model.PetDto
import eu.petsontrail.tracker.dtos.MyPetDto
import eu.petsontrail.tracker.services.AuthenticationCallCredentials
import getmypets.GetMyPetsRequestOuterClass
import io.grpc.ManagedChannelBuilder
import kotlinx.coroutines.runBlocking
import pets.PetsGrpc
import java.time.Instant
import java.time.LocalDateTime
import java.time.ZoneOffset
import java.util.UUID

class MyPetsFragment : Fragment() {
    private var _binding: FragmentMyPetsBinding? = null
    private val binding get() = _binding!!

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
    }

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        _binding = FragmentMyPetsBinding.inflate(inflater, container, false)

        return binding.root
    }

    @RequiresApi(Build.VERSION_CODES.O)
    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        val myPetsLists: ArrayList<MyPetDto> = ArrayList()

        runBlocking {
            val token = AppDatabase.getDatabase(requireContext(), this).userSettingsDao().getAccessToken()

            val channel = ManagedChannelBuilder
                .forTarget("dns:///petsontrail.eu:4443")
                .build()

            var client = PetsGrpc
                .newBlockingStub(channel)
                .withCallCredentials(AuthenticationCallCredentials(token))

            var response = client.getMyPets(GetMyPetsRequestOuterClass.GetMyPetsRequest.newBuilder().build())

            for (pet in response.petsList) {
                myPetsLists.add(MyPetDto(UUID.fromString(pet.id), pet.name, pet.chip))

                if (AppDatabase.getDatabase(requireContext(), this).petDao().getById(UUID.fromString(pet.id)) == null) {
                    val birthday = LocalDateTime.of(
                        pet.birthday.year,
                        pet.birthday.month,
                        pet.birthday.day,
                        0,
                        0,
                        0
                    )
                    val petDto = PetDto(
                        uid = UUID.fromString(pet.id),
                        groupId = UUID.fromString(Constants.UUID_EMPTY),
                        name = pet.name,
                        kennel = pet.kennel,
                        chip = pet.chip,
                        birthday = birthday.toEpochSecond(ZoneOffset.UTC),
                        breed = pet.pedigree,
                        color = ""
                    )

                    AppDatabase.getDatabase(requireContext(), this).petDao().insertOne(petDto)
                }
            }



            channel.shutdown()
        }

        val adapter = MyPetsAdapter(this.requireContext(), myPetsLists)

        binding.mypetslist.adapter = adapter
        binding.mypetslist.onItemClickListener = AdapterView.OnItemClickListener { parent, view, position, id ->
            val pet = parent.getItemAtPosition(position) as MyPetDto
            findNavController().navigate(R.id.action_myPetsFragment_to_createActivityFragment, bundleOf("addPetId" to pet.id.toString()))
        }

        binding.buttonAddPet.setOnClickListener {
            findNavController().navigate(R.id.action_myPetsFragment_to_addMyPetFragment)
        }
    }
}