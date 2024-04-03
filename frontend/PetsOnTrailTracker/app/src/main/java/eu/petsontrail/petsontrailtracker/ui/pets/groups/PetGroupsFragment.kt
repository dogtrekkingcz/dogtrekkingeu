package eu.petsontrail.petsontrailtracker.ui.pets.groups

import android.R
import android.content.DialogInterface
import android.os.Bundle
import android.os.Handler
import android.os.Looper
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.view.WindowManager
import android.widget.ArrayAdapter
import android.widget.Button
import android.widget.EditText
import android.widget.ListView
import androidx.appcompat.app.AppCompatActivity
import androidx.fragment.app.DialogFragment
import androidx.fragment.app.Fragment
import eu.petsontrail.petsontrailtracker.data.AppDatabase
import eu.petsontrail.petsontrailtracker.data.PetGroupDto
import eu.petsontrail.petsontrailtracker.databinding.FragmentPetGroupsBinding
import eu.petsontrail.petsontrailtracker.helper.DbHelper
import kotlinx.coroutines.runBlocking
import java.util.UUID

interface PetGroupsCloseListener {
    fun onClose()
}

class PetGroupsFragment(val listener: PetGroupsCloseListener) : DialogFragment() {
    private var _binding: FragmentPetGroupsBinding? = null
    private val binding get() = _binding!!
    private lateinit var db: AppDatabase

    override fun onCreateView(
        inflater: LayoutInflater,
        container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        _binding = FragmentPetGroupsBinding.inflate(inflater, container, false)
        db = DbHelper().InitializeDatabase(this.requireContext())

        val cancelButton: Button = binding.buttonCancel
        cancelButton.setOnClickListener {
            dismissNow()
        }

        val btnAdd: Button = binding.btnPetGroupsAddNew
        btnAdd.setOnClickListener {
            val etName: EditText = binding.editTextNameOfGroup
            val name: String = etName.text.toString()

            val petGroup: PetGroupDto = PetGroupDto(uid = UUID.randomUUID(), name = name, description = "")

            runBlocking {
                db.petGroupDao().insertOne(petGroup)

                reloadGroups()
            }
        }

        reloadGroups()

        return binding.root
    }

    override fun onResume() {
        super.onResume()
        activity?.window?.addFlags(WindowManager.LayoutParams.FLAG_LAYOUT_NO_LIMITS)
    }

    override fun onDestroyView() {
        super.onDestroyView()
        _binding = null
    }

    override fun onDismiss(dialog: DialogInterface) {
        listener.onClose()

        super.onDismiss(dialog)
    }

    fun reloadGroups() {
        runBlocking {
            val groups = db.petGroupDao().getAll()

            val view: ListView = binding.petGroupsContent

            var groupNames = ArrayList<String>()

            for (group in groups) {
                groupNames.add(group.name.toString())
            }

            val adapter = activity?.let {
                ArrayAdapter<String>(
                    it,
                    R.layout.simple_spinner_item,
                    groupNames
                )
            }

            view.adapter = adapter
        }
    }
}