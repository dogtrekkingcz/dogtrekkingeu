package eu.petsontrail.tracker.db.dao

import android.location.Location
import androidx.room.Dao
import androidx.room.Delete
import androidx.room.Insert
import androidx.room.Query
import androidx.room.Update
import eu.petsontrail.tracker.db.model.PetDto
import java.util.UUID

@Dao
interface PetDao {
    @Query("SELECT * FROM pets")
    suspend fun getAll(): List<PetDto>

    @Query("SELECT * FROM pets WHERE uid = :id")
    suspend fun getById(id: UUID): PetDto?

    @Query("SELECT * FROM pets WHERE uid IN (:ids)")
    suspend fun loadAllByIds(ids: Array<UUID>): List<PetDto>

    @Insert
    suspend fun insertOne(vararg pet: PetDto)

    @Update(PetDto::class)
    suspend fun update(obj: PetDto)

    @Delete
    suspend fun delete(pet: PetDto)
}