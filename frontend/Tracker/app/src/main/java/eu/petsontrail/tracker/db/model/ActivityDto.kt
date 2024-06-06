package eu.petsontrail.tracker.db.model

import androidx.room.ColumnInfo
import androidx.room.Entity
import androidx.room.PrimaryKey
import java.time.LocalDate
import java.util.UUID

@Entity(tableName = "my_activities")
data class ActivityDto(
    @PrimaryKey val uid: UUID,
    @ColumnInfo(name = "time") val time: Long?,
    @ColumnInfo(name = "name") val name: String?,
    @ColumnInfo(name = "description") val description: String?,
    @ColumnInfo(name = "type") val type: UUID?,
    @ColumnInfo(name = "active") val active: Int = 0,
    @ColumnInfo(name = "synchronize", defaultValue = "true") val synchronize: Boolean = true,
    @ColumnInfo(name = "synchronize_every_n_secs", defaultValue = "60") val synchronizeEveryNSecs: Int = 60,
    @ColumnInfo(name = "is_synchronized", defaultValue = "false") val isSynchronized: Boolean = false,
    @ColumnInfo(name = "start") var start: Long?,
    @ColumnInfo(name = "end") var end: Long?
)
