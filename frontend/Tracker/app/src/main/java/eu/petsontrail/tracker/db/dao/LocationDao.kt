package eu.petsontrail.tracker.db.dao

import android.location.Location
import androidx.lifecycle.LiveData
import androidx.room.Dao
import androidx.room.Delete
import androidx.room.Insert
import androidx.room.Query
import eu.petsontrail.tracker.db.model.ActivityDto
import eu.petsontrail.tracker.db.model.LocationDto
import java.util.UUID

@Dao
interface LocationDao {
    @Query("SELECT * FROM my_locations")
    suspend fun getAll(): List<LocationDto>

    @Query("SELECT * FROM my_locations")
    fun getAllLive(): LiveData<List<LocationDto>>

    @Query("SELECT * FROM my_locations WHERE uid IN (:locationIds)")
    suspend fun loadAllByIds(locationIds: IntArray): List<LocationDto>

    @Query("SELECT * FROM my_locations WHERE id_activity LIKE :activityId")
    suspend fun findByActivityId(activityId: UUID): List<LocationDto>

    @Insert
    suspend fun insertOne(vararg location: LocationDto)

    @Delete
    suspend fun delete(location: LocationDto)
}