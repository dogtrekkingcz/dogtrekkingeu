package eu.petsontrail.petsontrailtracker.data

import androidx.room.ColumnInfo
import androidx.room.Entity
import androidx.room.PrimaryKey
import java.time.LocalDate
import java.util.UUID

@Entity(tableName = "my_activities")
data class ActivityDto(
    @PrimaryKey val uid: UUID,
    @ColumnInfo(name = "time") var time: Long?,
    @ColumnInfo(name = "name") val name: String?,
    @ColumnInfo(name = "description") val description: String?,
    @ColumnInfo(name = "active") val active: Int = 0,
    @ColumnInfo(name = "synchronize") val synchronize: Boolean = true,
    @ColumnInfo(name = "synchronize_every_n_secs") val synchronizeEveryNSecs: Int = 60,
    @ColumnInfo(name = "is_synchronized") val isSynchronized: Boolean = false
)
