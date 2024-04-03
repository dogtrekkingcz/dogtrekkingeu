package eu.petsontrail.petsontrailtracker.ui.main

import android.content.Intent
import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.ArrayAdapter
import android.widget.Button
import android.widget.EditText
import android.widget.ListView
import androidx.appcompat.app.AlertDialog
import androidx.fragment.app.Fragment
import androidx.fragment.app.viewModels
import eu.petsontrail.petsontrailtracker.NewActivity
import eu.petsontrail.petsontrailtracker.NewPet
import eu.petsontrail.petsontrailtracker.NewPetCloseListener
import eu.petsontrail.petsontrailtracker.R
import eu.petsontrail.petsontrailtracker.data.AppDatabase
import eu.petsontrail.petsontrailtracker.data.PetGroupDto
import eu.petsontrail.petsontrailtracker.databinding.FragmentActivityPetsEditorBinding
import eu.petsontrail.petsontrailtracker.helper.DbHelper
import kotlinx.coroutines.runBlocking
import java.util.UUID

class ActivityPetsEditorFragment : Fragment() {
    private var _binding: FragmentActivityPetsEditorBinding? = null

    // This property is only valid between onCreateView and
    // onDestroyView.
    private val binding get() = _binding!!

    private lateinit var db: AppDatabase


    companion object {
        fun newInstance() = ActivityPetsEditorFragment()
    }

    private val viewModel: ActivityPetsEditorViewModel by viewModels()

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)

        // TODO: Use the ViewModel
    }

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View {
        _binding = FragmentActivityPetsEditorBinding.inflate(inflater, container, false)
        val root: View = binding.root

        db = DbHelper().InitializeDatabase(this.requireContext())

        val btnAddNewGroup: Button = binding.btnPetsEditorAddNewGroup
        btnAddNewGroup.setOnClickListener {
            addGroup()
        }

        val btnAddNewPet: Button = binding.btnPetsEditorAddNewPet
        btnAddNewPet.setOnClickListener {
            addPet()
        }

        val btnCancel: Button = binding.btnPetsEditorCancel
        btnCancel.setOnClickListener {
            val intent = Intent(activity, NewActivity::class.java)
            startActivity(intent)
        }

        reload()

        return root
    }

    fun addGroup()
    {
        val builder = AlertDialog.Builder(this.requireContext())
        val inflater = layoutInflater
        builder.setTitle("Enter name of group")
        val dialogLayout = inflater.inflate(R.layout.alert_dialog_with_edittext, null)
        val editText  = dialogLayout.findViewById<EditText>(R.id.editText)
        builder.setView(dialogLayout)
        builder.setPositiveButton("OK") { dialogInterface, i -> run {
                runBlocking {
                    val newGroup = PetGroupDto(UUID.randomUUID(), editText.text.toString(), "")
                    db.petGroupDao().insertOne(newGroup)

                    reload()
                }
            }
        }

        builder.show()
    }

    fun addPet() {
        val newPetDialog = NewPet(object: NewPetCloseListener {
            override fun onClose() {
                reload()
            }
        })

        newPetDialog.show(childFragmentManager, null)
    }

    fun reload() {
        runBlocking {
            var groupsListView: ListView = binding.petsContent

            var groups = db.petGroupDao().getAll()

            var groupNames = ArrayList<String>()

            for (group in groups) {
                groupNames.add(group.name.toString())
            }

            val adapter = activity?.let {
                ArrayAdapter<String>(
                    it,
                    android.R.layout.simple_spinner_item,
                    groupNames
                )
            }

            groupsListView.adapter = adapter
        }
    }
}