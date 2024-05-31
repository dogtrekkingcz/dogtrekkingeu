package eu.petsontrail.tracker.viewmodels
import android.app.Application
import androidx.lifecycle.AndroidViewModel
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.viewModelScope
import eu.petsontrail.tracker.db.AppDatabase
import eu.petsontrail.tracker.db.model.ActivityDto
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.launch
import kotlinx.coroutines.withContext
import kotlin.concurrent.thread

class ActivityViewModel (application: Application) : AndroidViewModel(application) {
    var activity: MutableLiveData<ActivityDto?> = MutableLiveData()

    init {
        viewModelScope.launch {
            runDBInBackground(application)
        }
    }

    suspend fun runDBInBackground(application: Application) = withContext(Dispatchers.IO) {
        thread(start=true, isDaemon=true) {
            while (true) {
                val innerActivity =
                    AppDatabase.getActivityDao(application, viewModelScope).getActiveNoSuspend()

                activity.postValue(innerActivity)

                Thread.sleep(1000)
            }
        }
    }
}