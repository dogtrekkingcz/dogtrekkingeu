package eu.petsontrail.petsontrailtracker.data

import androidx.room.ColumnInfo
import androidx.room.Entity
import androidx.room.PrimaryKey
import java.util.Date
import java.util.UUID

@Entity(tableName = "my_activities")
data class ActivityDto(
    @PrimaryKey val uid: UUID,
    @ColumnInfo(name = "time") val time: Date?,
    @ColumnInfo(name = "name") val name: String?,
    @ColumnInfo(name = "description") val description: String?,
)
