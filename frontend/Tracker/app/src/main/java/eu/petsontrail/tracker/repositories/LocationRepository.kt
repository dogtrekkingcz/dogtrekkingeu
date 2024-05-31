package eu.petsontrail.tracker.repositories

import androidx.lifecycle.LiveData
import eu.petsontrail.tracker.db.dao.ActivityDao
import eu.petsontrail.tracker.db.dao.LocationDao
import eu.petsontrail.tracker.db.model.ActivityDto
import eu.petsontrail.tracker.db.model.LocationDto

class LocationRepository(private val locationDao: LocationDao) {
    val locations: LiveData<List<LocationDto>> = locationDao.getAllLive()

    suspend fun insert(location: LocationDto) {
        locationDao.insertOne(location)
    }
}