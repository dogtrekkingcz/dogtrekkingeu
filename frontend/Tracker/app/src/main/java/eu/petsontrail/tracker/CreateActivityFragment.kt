package eu.petsontrail.tracker

import activities.ActivitiesGrpc
import android.os.Build
import android.os.Bundle
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.AdapterView
import android.widget.ArrayAdapter
import androidx.annotation.RequiresApi
import androidx.lifecycle.lifecycleScope
import androidx.navigation.fragment.findNavController
import com.google.protobuf.Empty
import eu.petsontrail.tracker.databinding.FragmentCreateActivityBinding
import eu.petsontrail.tracker.db.AppDatabase
import eu.petsontrail.tracker.db.model.ActivityDto
import eu.petsontrail.tracker.db.model.PreparingActivityDto
import eu.petsontrail.tracker.dtos.ActivityTypeDto
import eu.petsontrail.tracker.dtos.MyPetDto
import eu.petsontrail.tracker.dtos.PetTypeDto
import eu.petsontrail.tracker.services.AuthenticationCallCredentials
import eu.petsontrail.tracker.ui.pets.ActivityTypesAdapter
import eu.petsontrail.tracker.ui.pets.PetTypesAdapter
import getmypets.GetMyPetsRequestOuterClass
import io.grpc.ManagedChannelBuilder
import kotlinx.coroutines.runBlocking
import pets.PetsGrpc
import java.time.LocalDateTime
import java.time.ZoneOffset
import java.time.format.DateTimeFormatter
import java.util.Locale
import java.util.UUID

class CreateActivityFragment : Fragment() {
    private var _binding: FragmentCreateActivityBinding? = null
    private val binding get() = _binding!!
    private var _petList: ArrayList<UUID> = ArrayList()
    private var _activityTypeList: ArrayList<ActivityTypeDto> = ArrayList()
    private lateinit var _preparingActivity: PreparingActivityDto
    private var _selectedActivityType: ActivityTypeDto? = null

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
    }

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        _binding = FragmentCreateActivityBinding.inflate(inflater, container, false)

        var addingPetId = arguments?.get("addPetId") as String?
        if (addingPetId != null) {
            val preparingActivity = getPreparingActivity()

            if (preparingActivity.pet_01 == null)
                preparingActivity.pet_01 = UUID.fromString(addingPetId)
            else if (preparingActivity.pet_02 == null)
                preparingActivity.pet_02 = UUID.fromString(addingPetId)
            else if (preparingActivity.pet_03 == null)
                preparingActivity.pet_03 = UUID.fromString(addingPetId)
            else if (preparingActivity.pet_04 == null)
                preparingActivity.pet_04 = UUID.fromString(addingPetId)
            else if (preparingActivity.pet_05 == null)
                preparingActivity.pet_05 = UUID.fromString(addingPetId)
            else if (preparingActivity.pet_06 == null)
                preparingActivity.pet_06 = UUID.fromString(addingPetId)
            else if (preparingActivity.pet_07 == null)
                preparingActivity.pet_07 = UUID.fromString(addingPetId)
            else if (preparingActivity.pet_08 == null)
                preparingActivity.pet_08 = UUID.fromString(addingPetId)
            else if (preparingActivity.pet_09 == null)
                preparingActivity.pet_09 = UUID.fromString(addingPetId)
            else if (preparingActivity.pet_10 == null)
                preparingActivity.pet_10 = UUID.fromString(addingPetId)
            else if (preparingActivity.pet_11 == null)
                preparingActivity.pet_11 = UUID.fromString(addingPetId)
            else if (preparingActivity.pet_12 == null)
                preparingActivity.pet_12 = UUID.fromString(addingPetId)
            else if (preparingActivity.pet_13 == null)
                preparingActivity.pet_13 = UUID.fromString(addingPetId)
            else if (preparingActivity.pet_14 == null)
                preparingActivity.pet_14 = UUID.fromString(addingPetId)
            else if (preparingActivity.pet_15 == null)
                preparingActivity.pet_15 = UUID.fromString(addingPetId)
            else if (preparingActivity.pet_16 == null)
                preparingActivity.pet_16 = UUID.fromString(addingPetId)
            else if (preparingActivity.pet_17 == null)
                preparingActivity.pet_17 = UUID.fromString(addingPetId)
            else if (preparingActivity.pet_18 == null)
                preparingActivity.pet_18 = UUID.fromString(addingPetId)
            else if (preparingActivity.pet_19 == null)
                preparingActivity.pet_19 = UUID.fromString(addingPetId)
            else if (preparingActivity.pet_20 == null)
                preparingActivity.pet_20 = UUID.fromString(addingPetId)
            else if (preparingActivity.pet_21 == null)
                preparingActivity.pet_21 = UUID.fromString(addingPetId)
            else if (preparingActivity.pet_22 == null)
                preparingActivity.pet_22 = UUID.fromString(addingPetId)
            else if (preparingActivity.pet_23 == null)
                preparingActivity.pet_23 = UUID.fromString(addingPetId)
            else if (preparingActivity.pet_24 == null)
                preparingActivity.pet_24 = UUID.fromString(addingPetId)
            else if (preparingActivity.pet_25 == null)
                preparingActivity.pet_25 = UUID.fromString(addingPetId)
            else if (preparingActivity.pet_26 == null)
                preparingActivity.pet_26 = UUID.fromString(addingPetId)
            else if (preparingActivity.pet_27 == null)
                preparingActivity.pet_27 = UUID.fromString(addingPetId)
            else if (preparingActivity.pet_28 == null)
                preparingActivity.pet_28 = UUID.fromString(addingPetId)
            else if (preparingActivity.pet_29 == null)
                preparingActivity.pet_29 = UUID.fromString(addingPetId)
            else if (preparingActivity.pet_30 == null)
                preparingActivity.pet_30 = UUID.fromString(addingPetId)

            runBlocking {
                AppDatabase.getDatabase(requireContext(), lifecycleScope).preparingActivityDao().update(preparingActivity)
            }

            if (preparingActivity.pet_01 != null)
                _petList.add(preparingActivity.pet_01!!)
            if (preparingActivity.pet_02 != null)
                _petList.add(preparingActivity.pet_02!!)
            if (preparingActivity.pet_03 != null)
                _petList.add(preparingActivity.pet_03!!)
            if (preparingActivity.pet_04 != null)
                _petList.add(preparingActivity.pet_04!!)
            if (preparingActivity.pet_05 != null)
                _petList.add(preparingActivity.pet_05!!)
            if (preparingActivity.pet_06 != null)
                _petList.add(preparingActivity.pet_06!!)
            if (preparingActivity.pet_07 != null)
                _petList.add(preparingActivity.pet_07!!)
            if (preparingActivity.pet_08 != null)
                _petList.add(preparingActivity.pet_08!!)
            if (preparingActivity.pet_09 != null)
                _petList.add(preparingActivity.pet_09!!)
            if (preparingActivity.pet_10 != null)
                _petList.add(preparingActivity.pet_10!!)
            if (preparingActivity.pet_11 != null)
                _petList.add(preparingActivity.pet_11!!)
            if (preparingActivity.pet_12 != null)
                _petList.add(preparingActivity.pet_12!!)
            if (preparingActivity.pet_13 != null)
                _petList.add(preparingActivity.pet_13!!)
            if (preparingActivity.pet_14 != null)
                _petList.add(preparingActivity.pet_14!!)
            if (preparingActivity.pet_15 != null)
                _petList.add(preparingActivity.pet_15!!)
            if (preparingActivity.pet_16 != null)
                _petList.add(preparingActivity.pet_16!!)
            if (preparingActivity.pet_17 != null)
                _petList.add(preparingActivity.pet_17!!)
            if (preparingActivity.pet_18 != null)
                _petList.add(preparingActivity.pet_18!!)
            if (preparingActivity.pet_19 != null)
                _petList.add(preparingActivity.pet_19!!)
            if (preparingActivity.pet_20 != null)
                _petList.add(preparingActivity.pet_20!!)
            if (preparingActivity.pet_21 != null)
                _petList.add(preparingActivity.pet_21!!)
            if (preparingActivity.pet_22 != null)
                _petList.add(preparingActivity.pet_22!!)
            if (preparingActivity.pet_23 != null)
                _petList.add(preparingActivity.pet_23!!)
            if (preparingActivity.pet_24 != null)
                _petList.add(preparingActivity.pet_24!!)
            if (preparingActivity.pet_25 != null)
                _petList.add(preparingActivity.pet_25!!)
            if (preparingActivity.pet_26 != null)
                _petList.add(preparingActivity.pet_26!!)
            if (preparingActivity.pet_27 != null)
                _petList.add(preparingActivity.pet_27!!)
            if (preparingActivity.pet_28 != null)
                _petList.add(preparingActivity.pet_28!!)
            if (preparingActivity.pet_29 != null)
                _petList.add(preparingActivity.pet_29!!)
            if (preparingActivity.pet_30 != null)
                _petList.add(preparingActivity.pet_30!!)

            arguments?.clear()
        }

        return binding.root
    }

    @RequiresApi(Build.VERSION_CODES.O)
    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        val arrayAdapter: ArrayAdapter<*>

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
                if (_petList.contains(UUID.fromString(pet.id))) {
                    myPetsLists.add(MyPetDto(UUID.fromString(pet.id), pet.name, pet.chip))
                }
            }

            var activityClient = ActivitiesGrpc.newBlockingStub(channel).withCallCredentials(AuthenticationCallCredentials(token))
            var activityTypes = activityClient.getActivityTypes(Empty.newBuilder().build())
            for (activityType in activityTypes.activityTypesList) {
                _activityTypeList.add(ActivityTypeDto(UUID.fromString(activityType.id), activityType.name, activityType.description))
            }
            binding.createActivityTypeOfActivity.onItemClickListener = AdapterView.OnItemClickListener { parent, _, position, _ ->
                _selectedActivityType = parent.getItemAtPosition(position) as ActivityTypeDto
            }

            val adapter = ActivityTypesAdapter(requireContext(), _activityTypeList)
            binding.createActivityTypeOfActivity.setAdapter(adapter)
        }

        // access the listView from xml file
        var mListView = binding.activePetsList
        arrayAdapter = ArrayAdapter(this.requireContext(), android.R.layout.simple_list_item_1, myPetsLists)
        mListView.adapter = arrayAdapter

        binding.createActivityNameOfActivity.setText(getPreparingActivity().name)
        binding.createActivityDescriptionOfActivity.setText(getPreparingActivity().description)

        binding.buttonAddPet.setOnClickListener {
            findNavController().navigate(R.id.action_createActivityFragment_to_myPetsFragment)
        }

        binding.buttonActivityCreate.setOnClickListener {
            runBlocking {
                if (AppDatabase.getDatabase(requireContext(), this).activityDao().getActive() != null) {
                    AppDatabase.getDatabase(requireContext(), this).activityDao().resetActiveActivities()
                }

                var nameOfActivity: String? = null

                if (binding.createActivityNameOfActivity.text!!.isEmpty()) {
                    nameOfActivity = LocalDateTime.now()
                        .format(
                            DateTimeFormatter.ofPattern(
                                "yyyy-MM-dd HH:mm:ss",
                                Locale.ENGLISH
                            )
                        )

                    binding.createActivityNameOfActivity.setText(nameOfActivity)
                } else {
                    nameOfActivity = binding.createActivityNameOfActivity.text.toString()
                }

                var newActivity = ActivityDto(
                    uid = UUID.randomUUID(),
                    time = LocalDateTime.now().toEpochSecond(ZoneOffset.UTC),
                    name = nameOfActivity,
                    type = _selectedActivityType!!.id,
                    active = 1,
                    description = "",
                    start = null,
                    end = null
                )

                AppDatabase.getDatabase(requireContext(), this).activityDao().insertOne(newActivity)
            }

            findNavController().navigate(R.id.action_createActivityFragment_to_activityFragment)
        }

        binding.buttonActivityCancel.setOnClickListener {
            findNavController().navigate(R.id.action_createActivityFragment_to_activityFragment)
        }
    }

    private fun getPreparingActivity(): PreparingActivityDto {
        var preparingActivity: PreparingActivityDto? = null

        runBlocking {
            preparingActivity = AppDatabase.getDatabase(requireContext(), lifecycleScope).preparingActivityDao().get()

            if (preparingActivity == null) {
                preparingActivity = PreparingActivityDto(
                    uid = UUID.randomUUID(),
                    name = null,
                    description = null,
                    actionId = null,
                    type = null,
                    pet_01 = null,
                    pet_02 = null,
                    pet_03 = null,
                    pet_04 = null,
                    pet_05 = null,
                    pet_06 = null,
                    pet_07 = null,
                    pet_08 = null,
                    pet_09 = null,
                    pet_10 = null,
                    pet_11 = null,
                    pet_12 = null,
                    pet_13 = null,
                    pet_14 = null,
                    pet_15 = null,
                    pet_16 = null,
                    pet_17 = null,
                    pet_18 = null,
                    pet_19 = null,
                    pet_20 = null,
                    pet_21 = null,
                    pet_22 = null,
                    pet_23 = null,
                    pet_24 = null,
                    pet_25 = null,
                    pet_26 = null,
                    pet_27 = null,
                    pet_28 = null,
                    pet_29 = null,
                    pet_30 = null
                )

                AppDatabase.getDatabase(requireContext(), lifecycleScope).preparingActivityDao().insertOne(preparingActivity!!)
            }

            _preparingActivity = preparingActivity!!
        }

        return preparingActivity!!
    }
}