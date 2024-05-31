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
import com.google.android.material.datepicker.MaterialDatePicker
import com.google.protobuf.Empty
import com.google.type.DateTime
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
import java.time.Instant
import java.util.Calendar
import java.util.TimeZone
import java.util.UUID

class AddMyPetFragment : Fragment() {
    private var _binding: FragmentAddMyPetBinding? = null
    private val binding get() = _binding!!
    private var _petBirthday: DateTime? = null

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

        runBlocking {
            val token = _db.userSettingsDao().getAccessToken()

            val channel = ManagedChannelBuilder
                .forTarget("dns:///petsontrail.eu:4443")
                .build()

            var client = PetsGrpc
                .newBlockingStub(channel)
                .withCallCredentials(AuthenticationCallCredentials(token))

            val petTypes = client.getPetTypes(
                Empty.newBuilder()
                    .build()
            )

            binding.editTextPetType.setAdapter(
                ArrayAdapter(
                    requireContext(),
                    android.R.layout.simple_list_item_1,
                    petTypes.petTypesList.map { it -> it.name }
                )
            )
        }

        binding.editTextPetBirthday.setOnClickListener {
            val datePicker =
                MaterialDatePicker.Builder.datePicker()
                    .setTitleText("Select date")
                    .setSelection(MaterialDatePicker.todayInUtcMilliseconds())
                    .build()

            datePicker.addOnPositiveButtonClickListener {
                val calendar = Calendar.getInstance(TimeZone.getTimeZone("UTC"))
                calendar.timeInMillis = it

                val year = calendar.get(Calendar.YEAR)
                val month = calendar.get(Calendar.MONTH) + 1
                val day = calendar.get(Calendar.DAY_OF_MONTH)

                _petBirthday = DateTime.newBuilder()
                                        .setYear(year)
                                        .setMonth(month)
                                        .setDay(day)
                                        .build()


                binding.editTextPetBirthday.setText("$year-$month-$day")
            }

            datePicker.show(parentFragmentManager, "datePicker")
        }

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
                        .setId(UUID.randomUUID().toString())
                        .setName(binding.editTextPetName.text.toString())
                        .setChip(binding.editTextPetChip.text.toString())
                        .setPedigree(binding.editTextPetPedigree.text.toString())
                        .setKennel(binding.editTextPetKennel.text.toString())
                        .setBirthday(_petBirthday)
                        .setPetType(UUID.randomUUID().toString()) // TODO: get from backend
                        .build()
                )
            }

            findNavController().navigate(R.id.action_addMyPetFragment_to_myPetsFragment)
        }
    }
}