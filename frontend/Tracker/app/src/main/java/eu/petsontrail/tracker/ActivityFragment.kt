package eu.petsontrail.tracker

import android.Manifest
import android.R
import android.content.Intent
import android.content.pm.PackageManager
import android.os.Build
import android.os.Bundle
import android.util.Log
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import androidx.annotation.RequiresApi
import androidx.core.app.ActivityCompat
import androidx.fragment.app.Fragment
import androidx.fragment.app.FragmentTransaction
import androidx.fragment.app.viewModels
import androidx.lifecycle.Observer
import androidx.lifecycle.lifecycleScope
import androidx.navigation.fragment.findNavController
import eu.petsontrail.tracker.databinding.FragmentActivityBinding
import eu.petsontrail.tracker.db.AppDatabase
import eu.petsontrail.tracker.db.DbHelper
import eu.petsontrail.tracker.db.model.ActivityDto
import eu.petsontrail.tracker.db.model.LocationDto
import eu.petsontrail.tracker.helpers.DistanceHelper
import eu.petsontrail.tracker.services.LocationTrackerService
import kotlinx.coroutines.invoke
import kotlinx.coroutines.runBlocking
import java.util.UUID


// TODO: Rename parameter arguments, choose names that match
// the fragment initialization parameters, e.g. ARG_ITEM_NUMBER
private const val ARG_PARAM1 = "param1"
private const val ARG_PARAM2 = "param2"

/**
 * A simple [Fragment] subclass.
 * Use the [ActivityFragment.newInstance] factory method to
 * create an instance of this fragment.
 */
class ActivityFragment : Fragment() {
    private var _binding: FragmentActivityBinding? = null
    private val binding get() = _binding!!

    private val model: ActivityViewModel by viewModels()

    private lateinit var _db: AppDatabase

    private val REQUEST_PERMISSION_LOCATIONS = 1;
    private var _activityId: UUID? = null
    private var _duration = 0.0

    var _observerActivityRunning: Observer<List<LocationDto>>? = null

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)

        runBlocking {
            val observerActivityGeneral = Observer<ActivityDto?> {
                if (it != null) {
                    binding.textViewActivityName.text = it.name

                    if (it.start != null) {
                        val now = System.currentTimeMillis()
                        _duration = (now - it.start)/1000 as Double
                    }

                    binding.textViewActivityDuration.text = _duration.toString()
                }
            }

            _observerActivityRunning = Observer<List<LocationDto>> {
                var distance = 0.0
                var speed = 0.0

                if (it.size > 1) {
                    distance = DistanceHelper().GetDistanceInMeters(it)
                    speed = distance / _duration * 3600
                }

                binding.textViewActivityDistance.text = distance.toString()
                binding.textViewActivitySpeed.text = speed.toString()
            }

            _db.activityDao().getActive().observe(viewLifecycleOwner, observerActivityGeneral)
        }
    }

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        _binding = FragmentActivityBinding.inflate(inflater, container, false)
        _db = DbHelper().InitializeDatabase(this.requireContext())

        return binding.root
    }

    @RequiresApi(Build.VERSION_CODES.O)
    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        binding.buttonCreateNewActivity.setOnClickListener {
            findNavController().navigate(R.id.action_activityFragment_to_createActivityFragment)
        }

        binding.buttonActivityStart.setOnClickListener {
            if (ActivityCompat.checkSelfPermission(this.requireContext(), Manifest.permission.ACCESS_FINE_LOCATION) != PackageManager.PERMISSION_GRANTED
                || ActivityCompat.checkSelfPermission(this.requireContext(), Manifest.permission.ACCESS_COARSE_LOCATION) != PackageManager.PERMISSION_GRANTED
                || ActivityCompat.checkSelfPermission(this.requireContext(), Manifest.permission.ACCESS_BACKGROUND_LOCATION) != PackageManager.PERMISSION_GRANTED
                || ActivityCompat.checkSelfPermission(this.requireContext(), Manifest.permission.FOREGROUND_SERVICE) != PackageManager.PERMISSION_GRANTED
                || ActivityCompat.checkSelfPermission(this.requireContext(), Manifest.permission.FOREGROUND_SERVICE_LOCATION) != PackageManager.PERMISSION_GRANTED
                || ActivityCompat.checkSelfPermission(this.requireContext(), Manifest.permission.INTERNET) != PackageManager.PERMISSION_GRANTED
                || ActivityCompat.checkSelfPermission(this.requireContext(), Manifest.permission.POST_NOTIFICATIONS) != PackageManager.PERMISSION_GRANTED
                || ActivityCompat.checkSelfPermission(this.requireContext(), Manifest.permission.FOREGROUND_SERVICE_DATA_SYNC) != PackageManager.PERMISSION_GRANTED
            ) {
                Log.d("permission", "no permission for locations is configured")

                val requestedPermissions = arrayOf(
                    Manifest.permission.ACCESS_FINE_LOCATION,
                    Manifest.permission.ACCESS_COARSE_LOCATION,
                    Manifest.permission.ACCESS_BACKGROUND_LOCATION,
                    Manifest.permission.FOREGROUND_SERVICE,
                    Manifest.permission.FOREGROUND_SERVICE_LOCATION,
                    Manifest.permission.INTERNET,
                    Manifest.permission.POST_NOTIFICATIONS,
                    Manifest.permission.FOREGROUND_SERVICE_DATA_SYNC)

                ActivityCompat.requestPermissions(
                    this.requireActivity(),
                    requestedPermissions,
                    REQUEST_PERMISSION_LOCATIONS)
            }

            val intent = Intent(this.context, LocationTrackerService::class.java)
            this.context?.startForegroundService(intent)

            if (_activityId != null && _observerActivityRunning != null) {
                runBlocking {
                    _db.locationDao().findByActivityId(_activityId!!).observe(viewLifecycleOwner, _observerActivityRunning!!)
                }
            }
        }

        binding.buttonActivityStop.setOnClickListener {
            val intent = Intent(this.context, LocationTrackerService::class.java)
            this.context?.stopService(intent)
        }
    }
}