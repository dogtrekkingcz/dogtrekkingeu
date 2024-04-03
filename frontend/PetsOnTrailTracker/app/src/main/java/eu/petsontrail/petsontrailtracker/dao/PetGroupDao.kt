package eu.petsontrail.petsontrailtracker.dao

import android.location.Location
import androidx.room.Dao
import androidx.room.Delete
import androidx.room.Insert
import androidx.room.Query
import eu.petsontrail.petsontrailtracker.data.ActivityDto
import eu.petsontrail.petsontrailtracker.data.LocationDto
import eu.petsontrail.petsontrailtracker.data.PetGroupDto
import java.util.UUID

@Dao
interface PetGroupDao {
    @Query("SELECT * FROM pet_groups")
    suspend fun getAll(): List<PetGroupDto>

    @Query("SELECT * FROM pet_groups WHERE uid IN (:ids)")
    suspend fun loadAllByIds(ids: Array<UUID>): List<PetGroupDto>

    @Insert
    suspend fun insertOne(vararg petGroup: PetGroupDto)

    @Delete
    suspend fun delete(petGroup: PetGroupDto)
}