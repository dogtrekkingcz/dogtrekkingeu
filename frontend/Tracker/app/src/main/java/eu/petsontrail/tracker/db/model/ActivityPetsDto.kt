package eu.petsontrail.tracker.db.model

import androidx.room.ColumnInfo
import androidx.room.Entity
import androidx.room.PrimaryKey
import java.time.LocalDate
import java.util.Date
import java.util.UUID

@Entity(tableName = "activity_pets")
data class ActivityPetsDto(
    @PrimaryKey val uid: UUID,
    @ColumnInfo(name = "activity_id") val activityId: UUID,
    @ColumnInfo(name = "pet_id") val petId: UUID,
    @ColumnInfo(name = "note") val note: String?
)
