package eu.petsontrail.petsontrailtracker.ui.newactivity

import android.content.Intent
import android.os.Build
import androidx.fragment.app.viewModels
import android.os.Bundle
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Button
import android.widget.EditText
import android.widget.HorizontalScrollView
import androidx.annotation.RequiresApi
import androidx.lifecycle.ViewModelProvider
import eu.petsontrail.petsontrailtracker.ActivityPetsEditor

import eu.petsontrail.petsontrailtracker.R
import eu.petsontrail.petsontrailtracker.data.ActivityDto
import eu.petsontrail.petsontrailtracker.data.AppDatabase
import eu.petsontrail.petsontrailtracker.databinding.FragmentNewActivityActivityBinding
import eu.petsontrail.petsontrailtracker.helper.DbHelper
import eu.petsontrail.petsontrailtracker.ui.pets.list.PetLineFragment
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

        _binding = FragmentNewActivityActivityBinding.inflate(inflater, container, false)
        val root: View = binding.root

        db = DbHelper().InitializeDatabase(this.requireContext())

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
                    description = ""
                )

                db.activityDao().insertOne(newActivity)
            }
        }

        val btnPetsEditor: Button = binding.btnNewActivityPetsEditor
        btnPetsEditor.setOnClickListener {
            val intent = Intent(this.context, ActivityPetsEditor::class.java)
            startActivity(intent)
        }

        val petListView: HorizontalScrollView = binding.listOfPets

        val pet: PetLineFragment = PetLineFragment()

        return root
    }

}