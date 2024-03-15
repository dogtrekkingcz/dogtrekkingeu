package eu.petsontrail.petsontrailtracker.ui.activities

import MIGRATION_1_2
import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.ArrayAdapter
import android.widget.Button
import android.widget.ListView
import androidx.fragment.app.Fragment
import androidx.lifecycle.ViewModelProvider
import androidx.room.Room
import eu.petsontrail.petsontrailtracker.data.AppDatabase
import eu.petsontrail.petsontrailtracker.data.LocationDto
import eu.petsontrail.petsontrailtracker.databinding.FragmentActivitiesBinding
import eu.petsontrail.petsontrailtracker.helper.DistanceHelper
import kotlinx.coroutines.runBlocking
import java.util.Collections


class ActivitiesFragment : Fragment() {

    private var _binding: FragmentActivitiesBinding? = null

    // This property is only valid between onCreateView and
    // onDestroyView.
    private val binding get() = _binding!!

    private lateinit var db: AppDatabase

    override fun onCreateView(
            inflater: LayoutInflater,
            container: ViewGroup?,
            savedInstanceState: Bundle?
    ): View {
        val activitiesViewModel =
                ViewModelProvider(this).get(ActivitiesViewModel::class.java)

        db = Room.databaseBuilder(
            this.requireContext(),
            AppDatabase::class.java, "petsOnTrailTracker_db"
        )
            .addMigrations(MIGRATION_1_2)
            .build()

        _binding = FragmentActivitiesBinding.inflate(inflater, container, false)
        val root: View = binding.root


        val reloadActivities: Button = binding.reloadActivitiesButton
        reloadActivities.setOnClickListener {
            reloadData()
        }

        val cleanEmptyActivities: Button = binding.cleanEmptyActivitiesButton
        cleanEmptyActivities.setOnClickListener {
            runBlocking {
                var allActivities = db.activityDao().getAll()

                for (activity in allActivities) {
                    var activityLocations = db.locationDao().findByActivityId(activity.uid)

                    if (activityLocations.size == 0)
                    {
                        db.activityDao().delete(activity)
                    }
                }
            }
        }

        reloadData()

        return root
    }

    override fun onDestroyView() {
        super.onDestroyView()
        _binding = null
    }

    fun reloadData() {
        val activityListView: ListView = binding.activityListView

        var activitiesNames = ArrayList<String>()

        runBlocking {
            var activities = db.activityDao().getAll().sortedByDescending { it -> it.time }

            for (activity in activities) {
                var activityLocations = db.locationDao().findByActivityId(activity.uid).toMutableList().sortedByDescending { it -> it.time }

                Collections.sort<LocationDto>(activityLocations, Comparator.comparing(LocationDto::time))

                var item = activity.name!! + " [" + activityLocations.size + "] -> [" + String.format("%.2f", DistanceHelper().GetDistanceInMeters(activityLocations)/1000) + "km]"

                activitiesNames.add(item)
            }

            val adapter = activity?.let {
                ArrayAdapter<String>(
                    it,
                    android.R.layout.simple_spinner_item,
                    activitiesNames
                )
            }

            activityListView.adapter = adapter
        }
    }
}