package eu.petsontrail.petsontrailtracker

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import eu.petsontrail.petsontrailtracker.ui.newactivity.NewActivityFragment

class NewActivity : AppCompatActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_new_activity)
        if (savedInstanceState == null) {
            supportFragmentManager.beginTransaction()
                .replace(R.id.container, NewActivityFragment.newInstance())
                .commitNow()
        }
    }
}