package eu.petsontrail.tracker.db.dao

import android.location.Location
import androidx.room.Dao
import androidx.room.Delete
import androidx.room.Insert
import androidx.room.Query
import androidx.room.Update
import eu.petsontrail.tracker.db.model.PetGroupDto
import java.util.UUID

@Dao
interface PetGroupDao {
    @Query("SELECT * FROM pet_groups")
    suspend fun getAll(): List<PetGroupDto>

    @Query("SELECT * FROM pet_groups WHERE uid IN (:ids)")
    suspend fun loadAllByIds(ids: Array<UUID>): List<PetGroupDto>

    @Insert
    suspend fun insertOne(vararg petGroup: PetGroupDto)

    @Update(PetGroupDto::class)
    suspend fun update(obj: PetGroupDto)

    @Delete
    suspend fun delete(petGroup: PetGroupDto)
}