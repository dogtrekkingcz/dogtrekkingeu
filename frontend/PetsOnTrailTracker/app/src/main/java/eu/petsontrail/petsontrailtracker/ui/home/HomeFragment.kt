package eu.petsontrail.petsontrailtracker.ui.home

import MIGRATION_1_2
import android.R
import android.content.Intent
import android.os.Build
import android.os.Bundle
import android.os.CountDownTimer
import android.util.Log
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
import eu.petsontrail.petsontrailtracker.data.ActivityDto
import eu.petsontrail.petsontrailtracker.data.AppDatabase
import eu.petsontrail.petsontrailtracker.databinding.FragmentHomeBinding
import eu.petsontrail.petsontrailtracker.helper.DistanceHelper
import kotlinx.coroutines.runBlocking
import java.lang.IllegalArgumentException
import java.time.LocalDateTime
import java.time.ZoneOffset
import java.time.format.DateTimeFormatter
import java.util.Locale
import java.util.Timer
import java.util.TimerTask
import java.util.UUID


class HomeFragment : Fragment() {

    private var _binding: FragmentHomeBinding? = null

    // This property is only valid between onCreateView and
    // onDestroyView.
    private val binding get() = _binding!!

    private lateinit var db: AppDatabase

    /*
    val timer = Timer().scheduleAtFixedRate(object: TimerTask() {
        override fun run() {
            reloadActivity()
        }
    }, 1000, 3000)

    */

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

        val btnStartTrackingService: Button = binding.buttonStartTracking
        btnStartTrackingService.setOnClickListener {
            runBlocking {
                if (db.activityDao().getActive() == null) {
                    var nameOfActivity: String? = null

                    val editTextNameOfActivity: EditText = binding.editTextNameOfActivity
                    if (editTextNameOfActivity.text.isEmpty()) {
                        nameOfActivity = LocalDateTime.now()
                            .format(
                                DateTimeFormatter.ofPattern(
                                    "yyyy-MM-dd HH:mm:ss",
                                    Locale.ENGLISH
                                )
                            )

                        editTextNameOfActivity.setText(nameOfActivity)
                    }
                    else {
                        nameOfActivity = editTextNameOfActivity.text.toString()
                    }

                    var newActivity = ActivityDto(
                        uid = UUID.randomUUID(),
                        time = LocalDateTime.now().toEpochSecond(ZoneOffset.UTC),
                        name = nameOfActivity,
                        active = 1,
                        description = ""
                    )

                    db.activityDao().insertOne(newActivity)
                }
            }

            val intent = Intent(this.context, LocationTrackerService::class.java)
            this.context?.startForegroundService(intent)
        }

        val btnStopTrackingService: Button = binding.buttonStopTrackingService
        btnStopTrackingService.setOnClickListener {
            val intent = Intent(this.context, LocationTrackerService::class.java)
            this.context?.stopService(intent)
        }

        val btnRefresh: Button = binding.buttonRefresh
        btnRefresh.setOnClickListener {
            runBlocking {
                reloadActivity()
            }
        }

        val btnNewActivity: Button = binding.buttonNewActivity
        btnNewActivity.setOnClickListener {
            runBlocking {
                db.activityDao().resetActiveActivities()

                var nameOfActivity: String? = null

                val editTextNameOfActivity: EditText = binding.editTextNameOfActivity
                if (editTextNameOfActivity.text.isEmpty()) {
                    nameOfActivity = LocalDateTime.now()
                        .format(
                            DateTimeFormatter.ofPattern(
                                "yyyy-MM-dd HH:mm:ss",
                                Locale.ENGLISH
                            )
                        )

                    editTextNameOfActivity.setText(nameOfActivity)
                }
                else {
                    nameOfActivity = editTextNameOfActivity.text.toString()
                }

                var newActivity = ActivityDto(
                    uid = UUID.randomUUID(),
                    time = LocalDateTime.now().toEpochSecond(ZoneOffset.UTC),
                    name = nameOfActivity,
                    active = 1,
                    description = ""
                )

                db.activityDao().insertOne(newActivity)

                reloadActivity()
            }
        }

        reloadActivity()

        return root
    }

    fun reloadActivity() {
        runBlocking {
            var activeActivity = db.activityDao().getActive()

            if (activeActivity == null)
                return@runBlocking

            if (activeActivity.name != null) {
                val editTextNameOfActivity: EditText = binding.editTextNameOfActivity

                Log.d("TAG", activeActivity.name!!)
                try {
                    editTextNameOfActivity.setText(activeActivity.name)
                }
                catch (ex: Exception) {
                    Log.d("TAG: '${activeActivity.name}'", ex.message!!)
                }
                catch (ex: IllegalArgumentException) {
                    Log.e("TAG", ex.toString())
                }
            }

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

            // val mapView: MapView = binding.mapView
        }
    }

    override fun onDestroyView() {
        super.onDestroyView()
        _binding = null
    }
}