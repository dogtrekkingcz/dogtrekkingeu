package eu.petsontrail.petsontrailtracker

import android.content.DialogInterface
import android.os.Build
import androidx.fragment.app.viewModels
import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.ArrayAdapter
import android.widget.Button
import android.widget.EditText
import android.widget.Spinner
import androidx.annotation.RequiresApi
import androidx.fragment.app.DialogFragment
import eu.petsontrail.petsontrailtracker.data.AppDatabase
import eu.petsontrail.petsontrailtracker.data.PetDto
import eu.petsontrail.petsontrailtracker.databinding.FragmentNewPetBinding
import eu.petsontrail.petsontrailtracker.databinding.FragmentPetGroupsBinding
import eu.petsontrail.petsontrailtracker.helper.DbHelper
import kotlinx.coroutines.runBlocking
import java.time.LocalDateTime
import java.time.ZoneOffset
import java.util.Date
import java.util.UUID

interface NewPetCloseListener {
    fun onClose()
}

class NewPet(val closeListener: NewPetCloseListener) : DialogFragment() {
    private val viewModel: NewPetViewModel by viewModels()

    private var _binding: FragmentNewPetBinding? = null
    private val binding get() = _binding!!
    private lateinit var db: AppDatabase

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)

        // TODO: Use the ViewModel
    }

    @RequiresApi(Build.VERSION_CODES.O)
    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View {
        _binding = FragmentNewPetBinding.inflate(inflater, container, false)
        val root: View = binding.root
        db = DbHelper().InitializeDatabase(this.requireContext())

        val cancelButton: Button = binding.newPetCancelBtn
        cancelButton.setOnClickListener {
            dismissNow()
        }

        val okButton: Button = binding.newPetOkBtn
        okButton.setOnClickListener {
            runBlocking {
                val groups = db.petGroupDao().getAll().sortedBy { it -> it.name }

                val groupSpinner: Spinner = binding.newPetGroupSelection
                val selectedGroupId = groupSpinner.selectedItemId.toInt()

                val nameEditText: EditText = binding.newPetName
                val name = nameEditText.text.toString()

                val newPet = PetDto(UUID.randomUUID(), groups.get(selectedGroupId).uid, name, "", "1234aaa", LocalDateTime.now().toEpochSecond(ZoneOffset.UTC))
                db.petDao().insertOne(newPet)

                dismissNow()
            }
        }

        reload()

        return root
    }

    override fun onDismiss(dialog: DialogInterface) {
        closeListener.onClose()

        super.onDismiss(dialog)
    }

    fun reload() {
        runBlocking {
            val groups = db.petGroupDao().getAll().sortedBy { it -> it.name }

            val groupList = ArrayList<String>()

            for (group in groups) {
                groupList.add(group.name.toString())
            }

            val groupListAdapter = activity?.let {
                ArrayAdapter<String>(
                    it,
                    android.R.layout.simple_spinner_item,
                    groupList
                )
            }

            val groupSpinner: Spinner = binding.newPetGroupSelection
            groupSpinner.adapter = groupListAdapter
        }
    }
}