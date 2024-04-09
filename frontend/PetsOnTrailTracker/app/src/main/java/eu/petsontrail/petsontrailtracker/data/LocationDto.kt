package eu.petsontrail.petsontrailtracker.data

import android.location.Location
import androidx.room.ColumnInfo
import androidx.room.Entity
import androidx.room.PrimaryKey
import java.time.LocalDate
import java.util.UUID

@Entity(tableName = "my_locations")
data class LocationDto(
    @PrimaryKey val uid: UUID,
    @ColumnInfo(name = "time") val time: Long,
    @ColumnInfo(name = "id_activity") val activityId: UUID?,
    @ColumnInfo(name = "provider") val provider: String?,
    @ColumnInfo(name = "time_ms") val timeMs: Long?,
    @ColumnInfo(name = "elapsed_realtime_ns") val elapsedRealtimeNs: Long?,
    @ColumnInfo(name = "latitude_degrees") val latitudeDegrees: Double?,
    @ColumnInfo(name = "longitude_degrees") val longitudeDegrees: Double?,
    @ColumnInfo(name = "horizontal_accuracy_meters") val horizontalAccuracyMeters: Float?,
    @ColumnInfo(name = "altitude_meters") val altitudeMeters: Double?,
    @ColumnInfo(name = "speed_meters_per_second") val speedMetersPerSecond: Float?,
    @ColumnInfo(name = "bearing_degrees") val bearingDegrees: Float?,
    @ColumnInfo(name = "bearing_accuracy_degrees") val bearingAccuracyDegrees: Float?,
    @ColumnInfo(name = "is_synchronized") val isSynchronized: Boolean = false
)
