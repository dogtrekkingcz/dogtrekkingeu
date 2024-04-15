package eu.petsontrail.petsontrailtracker.ui.newactivity

import android.content.Context
import android.content.Intent
import android.os.Build
import androidx.fragment.app.viewModels
import android.os.Bundle
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.AdapterView
import android.widget.Button
import android.widget.EditText
import android.widget.ListView
import androidx.annotation.RequiresApi
import androidx.lifecycle.ViewModelProvider
import eu.petsontrail.petsontrailtracker.ActivityPetsEditor
import eu.petsontrail.petsontrailtracker.MainActivity

import eu.petsontrail.petsontrailtracker.PetListSelector.RawPetListAdapter
import eu.petsontrail.petsontrailtracker.PetListSelector.RawPetListItemDataModel
import eu.petsontrail.petsontrailtracker.PetListSelector.RawPetListView
import eu.petsontrail.petsontrailtracker.data.ActivityDto
import eu.petsontrail.petsontrailtracker.data.ActivityPetsDto
import eu.petsontrail.petsontrailtracker.data.AppDatabase
import eu.petsontrail.petsontrailtracker.databinding.FragmentNewActivityActivityBinding
import eu.petsontrail.petsontrailtracker.helper.DbHelper
import kotlinx.coroutines.runBlocking
import java.time.LocalDateTime
import java.time.ZoneOffset
import java.time.format.DateTimeFormatter
import java.util.Locale
import java.util.UUID

class NewActivityFragment : Fragment() {
    private var _binding: FragmentNewActivityActivityBinding? = null

    // This property is only valid between onCreateView and
    // onDestroyView.
    private val binding get() = _binding!!

    private lateinit var db: AppDatabase

    companion object {
        fun newInstance() = NewActivityFragment()
    }

    private val viewModel: NewActivityViewModel by viewModels()

    private lateinit var rawPetListView: RawPetListView

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)

        // TODO: Use the ViewModel
    }

    @RequiresApi(Build.VERSION_CODES.O)
    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View {
        val newActivityViewModel =
            ViewModelProvider(this).get(eu.petsontrail.petsontrailtracker.ui.newactivity.NewActivityViewModel::class.java)

        var context = this.requireContext()

        _binding = FragmentNewActivityActivityBinding.inflate(inflater, container, false)
        val root: View = binding.root

        db = DbHelper().InitializeDatabase(this.requireContext())

        rawPetListView = RawPetListView(this.requireContext(), binding.listOfPets)

        val btnConfirm: Button = binding.btnNewActivityConfirm
        btnConfirm.setOnClickListener {
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
                } else {
                    nameOfActivity = editTextNameOfActivity.text.toString()
                }

                var newActivity = ActivityDto(
                    uid = UUID.randomUUID(),
                    time = LocalDateTime.now().toEpochSecond(ZoneOffset.UTC),
                    name = nameOfActivity,
                    active = 1,
                    description = "",
                    start = LocalDateTime.now().toEpochSecond(ZoneOffset.UTC),
                    end = null
                )

                db.activityDao().insertOne(newActivity)

                for (pet in rawPetListView.SelectedPets()) {
                    var petActivity = ActivityPetsDto(
                        uid =  UUID.randomUUID(),
                        activityId = newActivity.uid,
                        petId = pet.uid,
                        note = ""
                    )

                    db.activityPetsDao().insertOne(petActivity)
                }

                val intent = Intent(context, MainActivity::class.java)
                startActivity(intent)
            }
        }

        val btnPetsEditor: Button = binding.btnNewActivityPetsEditor
        btnPetsEditor.setOnClickListener {
            val intent = Intent(this.context, ActivityPetsEditor::class.java)
            startActivity(intent)
        }

        reloadPetList(this.requireContext())

        return root
    }

    fun reloadPetList(context: Context) {
        rawPetListView.reload()
    }

}