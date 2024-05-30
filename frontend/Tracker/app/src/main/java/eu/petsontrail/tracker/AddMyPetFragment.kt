package eu.petsontrail.tracker

import addmypet.AddMyPetRequestOuterClass
import android.os.Build
import android.os.Bundle
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.ArrayAdapter
import androidx.annotation.RequiresApi
import androidx.navigation.fragment.findNavController
import eu.petsontrail.tracker.databinding.FragmentActivityBinding
import eu.petsontrail.tracker.databinding.FragmentAddMyPetBinding
import eu.petsontrail.tracker.databinding.FragmentCreateActivityBinding
import eu.petsontrail.tracker.db.AppDatabase
import eu.petsontrail.tracker.db.DbHelper
import eu.petsontrail.tracker.dtos.MyPetDto
import eu.petsontrail.tracker.services.AuthenticationCallCredentials
import getmypets.GetMyPetsRequestOuterClass
import io.grpc.ManagedChannelBuilder
import kotlinx.coroutines.runBlocking
import pets.PetsGrpc
import java.util.UUID

class AddMyPetFragment : Fragment() {
    private var _binding: FragmentAddMyPetBinding? = null
    private val binding get() = _binding!!

    private lateinit var _db: AppDatabase
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
    }

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        _binding = FragmentAddMyPetBinding.inflate(inflater, container, false)
        _db = DbHelper().InitializeDatabase(this.requireContext())

        return binding.root
    }

    @RequiresApi(Build.VERSION_CODES.O)
    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        binding.addMyPet.setOnClickListener {
            runBlocking {
                val token = _db.userSettingsDao().getAccessToken()

                val channel = ManagedChannelBuilder
                    .forTarget("dns:///petsontrail.eu:4443")
                    .build()

                var client = PetsGrpc
                    .newBlockingStub(channel)
                    .withCallCredentials(AuthenticationCallCredentials(token))

                client.addMyPet(
                    AddMyPetRequestOuterClass.AddMyPetRequest.newBuilder()
                        .setName(binding.editTextPetName.text.toString())
                        .setChip(binding.editTextPetChip.text.toString())
                        .build()
                )
            }

            findNavController().navigate(R.id.action_addMyPetFragment_to_myPetsFragment)
        }
    }
}