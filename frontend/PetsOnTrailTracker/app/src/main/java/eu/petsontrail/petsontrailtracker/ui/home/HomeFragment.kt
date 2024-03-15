package eu.petsontrail.petsontrailtracker.ui.home

import MIGRATION_1_2
import android.R
import android.content.Intent
import android.os.Build
import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Button
import android.widget.EditText
import android.widget.TextView
import androidx.annotation.RequiresApi
import androidx.fragment.app.Fragment
import androidx.lifecycle.ViewModelProvider
import androidx.room.Room
import com.google.android.gms.maps.MapView
import eu.petsontrail.petsontrailtracker.LocationTrackerService
import eu.petsontrail.petsontrailtracker.data.AppDatabase
import eu.petsontrail.petsontrailtracker.databinding.FragmentHomeBinding
import eu.petsontrail.petsontrailtracker.helper.DistanceHelper
import kotlinx.coroutines.runBlocking


class HomeFragment : Fragment() {

    private var _binding: FragmentHomeBinding? = null

    // This property is only valid between onCreateView and
    // onDestroyView.
    private val binding get() = _binding!!

    private lateinit var db: AppDatabase

    @RequiresApi(Build.VERSION_CODES.O)
    override fun onCreateView(
            inflater: LayoutInflater,
            container: ViewGroup?,
            savedInstanceState: Bundle?
    ): View {
        val homeViewModel =
                ViewModelProvider(this).get(HomeViewModel::class.java)

        db = Room.databaseBuilder(
            this.requireContext(),
            AppDatabase::class.java, "petsOnTrailTracker_db"
        )
            .addMigrations(MIGRATION_1_2)
            .build()

        _binding = FragmentHomeBinding.inflate(inflater, container, false)
        val root: View = binding.root

        val btnStartTrackingService: Button = binding.buttonStartStopTracking
        btnStartTrackingService.setOnClickListener {
            val intent = Intent(this.context, LocationTrackerService::class.java)
            this.context?.startForegroundService(intent)
        }

        val btnStopTrackingService: Button = binding.buttonStopTrackingService
        btnStopTrackingService.setOnClickListener {
            val intent = Intent(this.context, LocationTrackerService::class.java)
            this.context?.stopService(intent)
        }

        reloadActivity()

        return root
    }

    fun reloadActivity() {
        runBlocking {
            var activeActivity = db.activityDao().getActive()

            if (activeActivity == null)
                return@runBlocking

            val editTextNameOfActivity: EditText = binding.editTextNameOfActivity
            editTextNameOfActivity.setText(activeActivity.name!!)


            var locations = db.locationDao().findByActivityId(activeActivity.uid)
            if (locations.size == 0)
                return@runBlocking

            var sortedLocations = locations.sortedBy { point -> point.time }

            val textViewStart: TextView = binding.textViewStart
            textViewStart.setText(sortedLocations.firstOrNull()?.time.toString())

            val textViewDuration: TextView = binding.textViewDuration
            textViewDuration.setText((sortedLocations.lastOrNull()?.time!! - sortedLocations.firstOrNull()?.time!!).toString())

            var wholeDistanceInMeters = DistanceHelper().GetDistanceInMeters(sortedLocations)

            val textViewSpeed: TextView = binding.textViewSpeed

            val textViewDistance: TextView = binding.textViewDistance
            textViewDistance.setText(String.format("%.2f", wholeDistanceInMeters/1000))

            val textViewAltitude: TextView = binding.textViewAltitude

            val textViewSpeedPer10Secs: TextView = binding.textViewSpeedPer10Secs

            val mapView: MapView = binding.mapView
        }
    }

    override fun onDestroyView() {
        super.onDestroyView()
        _binding = null
    }
}