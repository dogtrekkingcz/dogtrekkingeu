package eu.petsontrail.petsontrailtracker.dao

import android.location.Location
import androidx.room.Dao
import androidx.room.Delete
import androidx.room.Insert
import androidx.room.Query
import eu.petsontrail.petsontrailtracker.data.ActivityDto
import eu.petsontrail.petsontrailtracker.data.LocationDto
import eu.petsontrail.petsontrailtracker.data.PetDto
import eu.petsontrail.petsontrailtracker.data.PetGroupDto
import java.util.UUID

@Dao
interface PetDao {
    @Query("SELECT * FROM pets")
    suspend fun getAll(): List<PetDto>

    @Query("SELECT * FROM pets WHERE uid IN (:ids)")
    suspend fun loadAllByIds(ids: IntArray): List<PetDto>

    @Insert
    suspend fun insertOne(vararg pet: PetDto)

    @Delete
    suspend fun delete(pet: PetDto)
}