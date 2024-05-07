package eu.petsontrail.tracker

import android.os.Bundle
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup

class CreateActivityFragment : Fragment() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
    }

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        /*
                    runBlocking {
                if (_db.activityDao().getActive() == null) {
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
                    }
                    else {
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
                }
            }
         */

        // Inflate the layout for this fragment
        return inflater.inflate(R.layout.fragment_create_activity, container, false)
    }
}