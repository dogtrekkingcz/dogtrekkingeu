package eu.petsontrail.petsontrailtracker.ui.notifications

import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import androidx.fragment.app.Fragment
import androidx.lifecycle.ViewModelProvider
import eu.petsontrail.petsontrailtracker.databinding.FragmentNotificationsBinding

class NotificationsFragment : Fragment() {

    private var _binding: FragmentNotificationsBinding? = null

    // This property is only valid between onCreateView and
    // onDestroyView.
    private val binding get() = _binding!!

    override fun onCreateView(
            inflater: LayoutInflater,
            container: ViewGroup?,
            savedInstanceState: Bundle?
    ): View {
        val notificationsViewModel =
                ViewModelProvider(this).get(NotificationsViewModel::class.java)

        _binding = FragmentNotificationsBinding.inflate(inflater, container, false)
        val root: View = binding.root
/*
        val port = 50051
        val channel = ManagedChannelBuilder.forAddress("192.168.0.13", port).usePlaintext().build()
        val stub = PingPongGrpcKt.PingPongCoroutineStub(channel)

        binding.buttonFirst.setOnClickListener {
            runBlocking {
                val request = Pingpong.PingPongMsg.newBuilder().setPayload("World").build()
                val response = stub.ping(request)
                Log.i("result", response.toString())
            }
        }
  */
        return root
    }

    override fun onDestroyView() {
        super.onDestroyView()
        _binding = null
    }
}