package eu.petsontrail.tracker.viewmodels
import android.app.Application
import androidx.lifecycle.AndroidViewModel
import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.viewModelScope
import eu.petsontrail.tracker.db.AppDatabase
import eu.petsontrail.tracker.db.model.ActivityDto
import eu.petsontrail.tracker.db.model.LocationDto
import eu.petsontrail.tracker.repositories.ActivityRepository
import eu.petsontrail.tracker.repositories.LocationRepository
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.launch
import kotlinx.coroutines.runBlocking
import kotlinx.coroutines.withContext
import java.util.UUID
import kotlin.concurrent.thread
import kotlin.coroutines.suspendCoroutine

class LocationViewModel (application: Application) : AndroidViewModel(application) {
    var locations: MutableLiveData<List<LocationDto>> = MutableLiveData()
    var _stop: Boolean = false
    val timeout = 1000L

    fun setActivityId(activityId: UUID?) {
        _stop = true
        Thread.sleep(timeout)

        _stop = false

        if (activityId == null) {
            return
        }

        viewModelScope.launch {
            runDBInBackground(getApplication(), activityId)
        }
    }

    suspend fun runDBInBackground(application: Application, activityId: UUID) = withContext(Dispatchers.IO) {
        thread(start=true, isDaemon=true) {
            while (_stop == false) {
                val innerLocations = AppDatabase.getLocationDao(application, viewModelScope).findByActivityIdNoSuspend(activityId)
                if (innerLocations.size > 1) {
                    locations.postValue(innerLocations)
                }

                Thread.sleep(timeout)
            }
        }
    }
}