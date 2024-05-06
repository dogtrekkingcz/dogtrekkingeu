package eu.petsontrail.tracker.db.model

import androidx.room.ColumnInfo
import androidx.room.Entity
import androidx.room.PrimaryKey
import java.time.LocalDate
import java.util.UUID

@Entity(tableName = "public_activities")
data class PublicActivityDto(
    @PrimaryKey val uid: UUID,
    @ColumnInfo(name = "time") var time: Long?,
    @ColumnInfo(name = "type") var type: String? = "dogtrekking",
    @ColumnInfo(name = "name") val name: String?,
    @ColumnInfo(name = "description") val description: String?,
    @ColumnInfo(name = "start") val start: Long?,
    @ColumnInfo(name = "finish") val finish: Long?,
    @ColumnInfo(name = "address_city") val addressCity: String?,
    @ColumnInfo(name = "address_street") val addressStreet: String?,
)
