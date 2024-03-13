package eu.petsontrail.petsontrailtracker.dao

import android.location.Location
import androidx.room.Dao
import androidx.room.Delete
import androidx.room.Insert
import androidx.room.Query
import eu.petsontrail.petsontrailtracker.data.ActivityDto
import eu.petsontrail.petsontrailtracker.data.LocationDto
import java.util.UUID

@Dao
interface LocationDao {
    @Query("SELECT * FROM my_locations")
    suspend fun getAll(): List<ActivityDto>

    @Query("SELECT * FROM my_locations WHERE uid IN (:locationIds)")
    suspend fun loadAllByIds(locationIds: IntArray): List<LocationDto>

    @Query("SELECT * FROM my_locations WHERE id_activity LIKE :activityId")
    suspend fun findByActivityId(activityId: UUID): List<LocationDto>

    @Insert
    suspend fun insertOne(vararg location: LocationDto)

    @Delete
    suspend fun delete(location: LocationDto)
}