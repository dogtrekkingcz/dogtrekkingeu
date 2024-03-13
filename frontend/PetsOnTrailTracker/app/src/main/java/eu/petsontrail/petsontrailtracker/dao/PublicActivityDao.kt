package eu.petsontrail.petsontrailtracker.dao

import androidx.room.Dao
import androidx.room.Query
import eu.petsontrail.petsontrailtracker.data.PublicActivityDto

@Dao
interface PublicActivityDao {
    @Query("SELECT * FROM public_activities")
    suspend fun getAll(): List<PublicActivityDto>
}