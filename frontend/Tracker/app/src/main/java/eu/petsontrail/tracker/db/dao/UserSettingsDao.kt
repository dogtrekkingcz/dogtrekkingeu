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
import eu.petsontrail.tracker.db.model.UserSettingsDto
import java.util.UUID

@Dao
interface UserSettingsDao {
    @Query("SELECT * FROM user_settings")
    suspend fun getAll(): List<UserSettingsDto>

    @Query("UPDATE user_settings SET access_token = :accessToken")
    suspend fun updateAccessToken(vararg accessToken: String)

    @Query("SELECT access_token FROM user_settings LIMIT 1")
    suspend fun getAccessToken(): String

    @Insert
    suspend fun insertOne(vararg userSettings: UserSettingsDto)

    @Delete
    suspend fun delete(userSettings: UserSettingsDto)
}