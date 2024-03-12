package eu.petsontrail.petsontrailtracker.mapper

import android.location.Location
import android.os.Build
import androidx.annotation.RequiresApi
import eu.petsontrail.petsontrailtracker.data.LocationDto
import java.time.LocalDate
import java.util.UUID

@RequiresApi(Build.VERSION_CODES.O)
fun Location.toLocationDto(activityId: UUID) = LocationDto(
    uid = UUID.randomUUID(),
    time = LocalDate.now(),
    activityId = activityId,
    provider = this.provider,
    timeMs = this.time,
    elapsedRealtimeNs = this.elapsedRealtimeNanos,
    latitudeDegrees = this.latitude,
    longitudeDegrees = this.longitude,
    horizontalAccuracyMeters = this.accuracy,
    altitudeMeters = this.altitude,
    speedMetersPerSecond = this.speed,
    bearingDegrees = this.bearing,
    bearingAccuracyDegrees = this.bearingAccuracyDegrees
)