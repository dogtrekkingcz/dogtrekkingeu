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
import eu.petsontrail.tracker.databinding.FragmentAddMyPetBinding
import eu.petsontrail.tracker.databinding.FragmentCreateActivityBinding
import eu.petsontrail.tracker.db.AppDatabase
import eu.petsontrail.tracker.db.DbHelper

class AddMyPetFragment : Fragment() {
    private var _binding: FragmentAddMyPetBinding? = null
    private val binding get() = _binding!!

    private lateinit var _db: AppDatabase
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
    }

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        _binding = FragmentAddMyPetBinding.inflate(inflater, container, false)
        _db = DbHelper().InitializeDatabase(this.requireContext())

        return binding.root
    }

    @RequiresApi(Build.VERSION_CODES.O)
    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        binding.addMyPet.setOnClickListener {
            findNavController().navigate(R.id.action_addMyPetFragment_to_myPetsFragment)
        }
    }
}