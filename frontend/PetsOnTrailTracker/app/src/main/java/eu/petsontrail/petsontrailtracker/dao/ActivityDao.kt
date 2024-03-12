package eu.petsontrail.petsontrailtracker.dao

import androidx.room.Dao
import androidx.room.Delete
import androidx.room.Insert
import androidx.room.Query
import eu.petsontrail.petsontrailtracker.data.ActivityDto

@Dao
interface ActivityDao {
    @Query("SELECT * FROM my_activities")
    fun getAll(): List<ActivityDto>

    @Query("SELECT * FROM my_activities WHERE uid IN (:activityIds)")
    fun loadAllByIds(activityIds: IntArray): List<ActivityDto>

    @Query("SELECT * FROM my_activities WHERE name LIKE :name LIMIT 1")
    fun findByName(name: String): ActivityDto

    @Insert
    fun insertAll(vararg activity: ActivityDto)

    @Delete
    fun delete(activity: ActivityDto)
}