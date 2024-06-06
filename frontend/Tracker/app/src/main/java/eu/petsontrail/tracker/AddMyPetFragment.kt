package eu.petsontrail.tracker

import addmypet.AddMyPetRequestOuterClass
import android.os.Build
import android.os.Bundle
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.AdapterView
import androidx.annotation.RequiresApi
import androidx.core.view.get
import androidx.navigation.fragment.findNavController
import com.google.android.material.datepicker.MaterialDatePicker
import com.google.protobuf.Empty
import com.google.type.DateTime
import eu.petsontrail.tracker.databinding.FragmentAddMyPetBinding
import eu.petsontrail.tracker.db.AppDatabase
import eu.petsontrail.tracker.dtos.PetTypeDto
import eu.petsontrail.tracker.services.AuthenticationCallCredentials
import eu.petsontrail.tracker.ui.pets.PetTypesAdapter
import io.grpc.ManagedChannelBuilder
import kotlinx.coroutines.runBlocking
import pets.PetsGrpc
import java.util.Calendar
import java.util.TimeZone
import java.util.UUID

class AddMyPetFragment : Fragment() {
    private var _binding: FragmentAddMyPetBinding? = null
    private val binding get() = _binding!!
    private var _petBirthday: DateTime? = null
    var _petTypeList: ArrayList<PetTypeDto> = ArrayList()
    var _selectedPetType: PetTypeDto? = null

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
    }

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        _binding = FragmentAddMyPetBinding.inflate(inflater, container, false)

        return binding.root
    }

    @RequiresApi(Build.VERSION_CODES.O)
    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        runBlocking {
            val token = AppDatabase.getDatabase(requireContext(), this).userSettingsDao().getAccessToken()

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

            for (petType in petTypes.petTypesList) {
                _petTypeList.add(PetTypeDto(UUID.fromString(petType.id), petType.name, petType.description))
            }

            channel.shutdown()

            val adapter = PetTypesAdapter(requireContext(), _petTypeList)
            binding.editTextPetType.setAdapter(adapter)

            binding.editTextPetType.onItemClickListener = AdapterView.OnItemClickListener { parent, _, position, _ ->
                _selectedPetType = parent.getItemAtPosition(position) as PetTypeDto
            }
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
                val token = AppDatabase.getDatabase(requireContext(), this).userSettingsDao().getAccessToken()
                val channel = ManagedChannelBuilder
                    .forTarget("dns:///petsontrail.eu:4443")
                    .build()
                var client = PetsGrpc
                    .newBlockingStub(channel)
                    .withCallCredentials(AuthenticationCallCredentials(token))

                var request = AddMyPetRequestOuterClass.AddMyPetRequest.newBuilder()
                    .setId(UUID.randomUUID().toString())

                if (_selectedPetType != null) {
                    request.setPetType(_selectedPetType?.id.toString())
                }
                if (_petBirthday != null) {
                    request.setBirthday(_petBirthday)
                }
                if (binding.editTextPetName.text.toString().isNotEmpty()) {
                    request.setName(binding.editTextPetName.text.toString())
                }
                if (binding.editTextPetChip.text.toString().isNotEmpty()) {
                    request.setChip(binding.editTextPetChip.text.toString())
                }
                if (binding.editTextPetPedigree.text.toString().isNotEmpty()) {
                    request.setPedigree(binding.editTextPetPedigree.text.toString())
                }
                if (binding.editTextPetKennel.text.toString().isNotEmpty()) {
                    request.setKennel(binding.editTextPetKennel.text.toString())
                }

                client.addMyPet(request.build())
            }

            findNavController().navigate(R.id.action_addMyPetFragment_to_myPetsFragment)
        }
    }
}