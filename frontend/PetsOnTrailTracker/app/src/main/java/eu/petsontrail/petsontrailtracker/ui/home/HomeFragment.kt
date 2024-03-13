package eu.petsontrail.petsontrailtracker.ui.home

import android.R
import android.annotation.SuppressLint
import android.content.Intent
import android.database.Cursor
import android.os.Build
import android.os.Bundle
import android.provider.CallLog
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Button
import android.widget.ListView
import androidx.annotation.RequiresApi
import androidx.fragment.app.Fragment
import androidx.lifecycle.ViewModelProvider
import androidx.loader.content.CursorLoader
import eu.petsontrail.petsontrailtracker.LocationTrackerService
import eu.petsontrail.petsontrailtracker.databinding.FragmentHomeBinding


class HomeFragment : Fragment() {

    private var _binding: FragmentHomeBinding? = null

    // This property is only valid between onCreateView and
    // onDestroyView.
    private val binding get() = _binding!!

    @RequiresApi(Build.VERSION_CODES.O)
    override fun onCreateView(
            inflater: LayoutInflater,
            container: ViewGroup?,
            savedInstanceState: Bundle?
    ): View {
        val homeViewModel =
                ViewModelProvider(this).get(HomeViewModel::class.java)

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

        return root
    }

    override fun onDestroyView() {
        super.onDestroyView()
        _binding = null
    }
}