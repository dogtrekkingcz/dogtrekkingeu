package eu.petsontrail.tracker

import android.Manifest
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
import androidx.fragment.app.viewModels
import androidx.lifecycle.Observer
import androidx.lifecycle.lifecycleScope
import androidx.navigation.fragment.findNavController
import eu.petsontrail.tracker.databinding.FragmentActivityBinding
import eu.petsontrail.tracker.db.AppDatabase
import eu.petsontrail.tracker.helpers.DistanceHelper
import eu.petsontrail.tracker.services.LocationTrackerService
import kotlinx.coroutines.invoke
import kotlinx.coroutines.runBlocking
import java.util.UUID

class ActivityFragment : Fragment() {
    private var _binding: FragmentActivityBinding? = null
    private val binding get() = _binding!!

    private val model: ActivityViewModel by viewModels()

    private val REQUEST_PERMISSION_LOCATIONS = 1;
    private var _activityId: UUID? = null
    private var _duration = 0.0

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
    }

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        _binding = FragmentActivityBinding.inflate(inflater, container, false)

        AppDatabase.getDatabase(this.requireContext(), lifecycleScope).activityDao().getLiveActive().observe( viewLifecycleOwner, Observer {
            if (it != null) {
                binding.textViewActivityName.text = it.name

                if (it.start != null) {
                    val now = System.currentTimeMillis()
                    _duration = (now - it.start)/ 1000.toDouble()
                }

                binding.textViewActivityDuration.text = _duration.toString()
            }
        })

        AppDatabase.getDatabase(this.requireContext(), lifecycleScope).locationDao().getAllLive().observe(viewLifecycleOwner, Observer {
            Log.d("location", "location updated")

            var distance = 0.0
            var speed = 0.0

            if (it.size > 1) {
                distance = DistanceHelper().GetDistanceInMeters(it)
                speed = distance / _duration * 3600
            }

            binding.textViewActivityDistance.text = distance.toString()
            binding.textViewActivitySpeed.text = speed.toString()
        })

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

            runBlocking {
                _activityId = AppDatabase.getDatabase(requireContext(), lifecycleScope).activityDao().getActive()?.uid
            }
        }

        binding.buttonActivityStop.setOnClickListener {
            val intent = Intent(this.context, LocationTrackerService::class.java)
            this.context?.stopService(intent)
        }
    }
}