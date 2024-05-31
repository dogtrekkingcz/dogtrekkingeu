package eu.petsontrail.tracker

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
import eu.petsontrail.tracker.databinding.FragmentCreateActivityBinding
import eu.petsontrail.tracker.databinding.FragmentMyPetsBinding
import eu.petsontrail.tracker.db.AppDatabase
import eu.petsontrail.tracker.db.DbHelper
import eu.petsontrail.tracker.db.model.ActivityDto
import kotlinx.coroutines.runBlocking
import java.time.LocalDateTime
import java.time.ZoneOffset
import java.time.format.DateTimeFormatter
import java.util.Locale
import java.util.UUID

class CreateActivityFragment : Fragment() {
    private var _binding: FragmentCreateActivityBinding? = null
    private val binding get() = _binding!!

    private lateinit var _db: AppDatabase

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
    }

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        _binding = FragmentCreateActivityBinding.inflate(inflater, container, false)
        _db = DbHelper().InitializeDatabase(this.requireContext())

        return binding.root
    }

    @RequiresApi(Build.VERSION_CODES.O)
    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        val arrayAdapter: ArrayAdapter<*>
        val myPets = arrayOf(
            "Virat Kohli", "Rohit Sharma"
        )

        // access the listView from xml file
        var mListView = binding.activePetsList
        arrayAdapter = ArrayAdapter(this.requireContext(), android.R.layout.simple_list_item_1, myPets)
        mListView.adapter = arrayAdapter

        binding.buttonAddPet.setOnClickListener {
            findNavController().navigate(R.id.action_createActivityFragment_to_myPetsFragment)
        }

        binding.buttonActivityCreate.setOnClickListener {
            runBlocking {
                if (_db.activityDao().getActive() != null) {
                    _db.activityDao().resetActiveActivities()
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
                    active = 1,
                    description = "",
                    start = LocalDateTime.now().toEpochSecond(ZoneOffset.UTC),
                    end = null
                )

                _db.activityDao().insertOne(newActivity)
            }

            findNavController().navigate(R.id.action_createActivityFragment_to_activityFragment)
        }

        binding.buttonActivityCancel.setOnClickListener {
            findNavController().navigate(R.id.action_createActivityFragment_to_activityFragment)
        }
    }
}