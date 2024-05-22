package eu.petsontrail.tracker.ui.pets

import android.os.Build
import android.os.Bundle
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.ArrayAdapter
import android.widget.ListView
import androidx.annotation.RequiresApi
import eu.petsontrail.tracker.databinding.FragmentActivityBinding
import eu.petsontrail.tracker.databinding.FragmentMyPetsBinding
import eu.petsontrail.tracker.db.AppDatabase
import eu.petsontrail.tracker.db.DbHelper
import eu.petsontrail.tracker.dtos.MyPetDto

class MyPetsFragment : Fragment() {
    private var _binding: FragmentMyPetsBinding? = null
    private val binding get() = _binding!!

    private lateinit var _db: AppDatabase

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)

        _db = DbHelper().InitializeDatabase(this.requireContext())
    }

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        _binding = FragmentMyPetsBinding.inflate(inflater, container, false)

        return binding.root
    }

    @RequiresApi(Build.VERSION_CODES.O)
    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)


        var myPetsLists: ArrayList<MyPetDto> = ArrayList()
        var adapter: MyPetsAdapter? = null

        myPetsLists.add(MyPetDto(1, " Mashu", "987576443"))
        myPetsLists.add(MyPetDto(2, " Azhar", "8787576768"))
        myPetsLists.add(MyPetDto(3, " Niyaz", "65757657657"))
        adapter = MyPetsAdapter(this.requireContext(), myPetsLists)
        binding.mypetslist.adapter = adapter
    }
}