package eu.petsontrail.petsontrailtracker

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import eu.petsontrail.petsontrailtracker.ui.main.ActivityPetsEditorFragment

class ActivityPetsEditor : AppCompatActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_activity_pets_editor)
        if (savedInstanceState == null) {
            supportFragmentManager.beginTransaction()
                .replace(R.id.container, ActivityPetsEditorFragment.newInstance())
                .commitNow()
        }
    }
}