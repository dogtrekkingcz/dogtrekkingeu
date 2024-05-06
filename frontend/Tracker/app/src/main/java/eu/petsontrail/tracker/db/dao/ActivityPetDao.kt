package eu.petsontrail.tracker.db.dao

import androidx.room.Dao
import androidx.room.Delete
import androidx.room.Insert
import androidx.room.Query
import eu.petsontrail.tracker.db.model.ActivityPetsDto
import java.util.UUID

@Dao
interface ActivityPetDao {
    @Query("SELECT * FROM activity_pets")
    suspend fun getAll(): List<ActivityPetsDto>

    @Query("SELECT * FROM activity_pets WHERE uid IN (:uids)")
    suspend fun loadAllByIds(uids: Array<UUID>): List<ActivityPetsDto>

    @Query("SELECT * FROM activity_pets WHERE activity_id = (:uid)")
    suspend fun loadAllByActivityId(uid: UUID): List<ActivityPetsDto>

    @Insert
    suspend fun insertOne(vararg activityPet: ActivityPetsDto)

    @Delete
    suspend fun delete(activityPet: ActivityPetsDto)
}