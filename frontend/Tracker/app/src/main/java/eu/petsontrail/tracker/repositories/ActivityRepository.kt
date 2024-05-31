package eu.petsontrail.tracker.repositories

import androidx.lifecycle.LiveData
import eu.petsontrail.tracker.db.dao.ActivityDao
import eu.petsontrail.tracker.db.model.ActivityDto

class ActivityRepository(private val activityDao: ActivityDao) {
    val activeActivity: LiveData<ActivityDto?> = activityDao.getLiveActive()

    suspend fun insert(activity: ActivityDto) {
        activityDao.insertOne(activity)
    }
}