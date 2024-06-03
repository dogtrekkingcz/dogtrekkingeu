package eu.petsontrail.tracker.db.dao

import androidx.room.Dao
import androidx.room.Delete
import androidx.room.Insert
import androidx.room.Query
import androidx.room.Update
import eu.petsontrail.tracker.db.model.PreparingActivityDto

@Dao
interface PreparingActivityDao {
    @Query("SELECT * FROM preparing_activity LIMIT 1")
    suspend fun get(): PreparingActivityDto?
    @Insert
    suspend fun insertOne(vararg activity: PreparingActivityDto)

    @Update(PreparingActivityDto::class)
    suspend fun update(obj: PreparingActivityDto)

    @Delete
    suspend fun delete(activity: PreparingActivityDto)
}