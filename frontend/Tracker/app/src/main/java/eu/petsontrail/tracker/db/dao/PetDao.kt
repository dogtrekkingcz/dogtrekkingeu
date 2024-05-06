package eu.petsontrail.tracker.db.dao

import android.location.Location
import androidx.room.Dao
import androidx.room.Delete
import androidx.room.Insert
import androidx.room.Query
import eu.petsontrail.tracker.db.model.ActivityDto
import eu.petsontrail.tracker.db.model.LocationDto
import eu.petsontrail.tracker.db.model.PetDto
import eu.petsontrail.tracker.db.model.PetGroupDto
import java.util.UUID

@Dao
interface PetDao {
    @Query("SELECT * FROM pets")
    suspend fun getAll(): List<PetDto>

    @Query("SELECT * FROM pets WHERE uid IN (:ids)")
    suspend fun loadAllByIds(ids: Array<UUID>): List<PetDto>

    @Insert
    suspend fun insertOne(vararg pet: PetDto)

    @Delete
    suspend fun delete(pet: PetDto)
}