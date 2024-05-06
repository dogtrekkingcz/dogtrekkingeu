package eu.petsontrail.tracker.db.dao

import androidx.room.Dao
import androidx.room.Query
import eu.petsontrail.tracker.db.model.PublicActivityDto

@Dao
interface PublicActivityDao {
    @Query("SELECT * FROM public_activities")
    suspend fun getAll(): List<PublicActivityDto>
}