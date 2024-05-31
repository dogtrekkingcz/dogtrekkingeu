package eu.petsontrail.tracker.helpers

import android.location.Location
import eu.petsontrail.tracker.db.model.LocationDto

class DistanceHelper {
    fun GetDistanceInMeters(locations: List<LocationDto>) : Double
    {
        var distance = 0.0;
        var previousLocation: LocationDto? = null
        var aLocation: Location = Location("point A")
        var bLocation: Location = Location("point B")

        for (location in locations) {
            if (previousLocation == null) {
                previousLocation = location

                aLocation.latitude = previousLocation.latitudeDegrees!!
                aLocation.longitude = previousLocation.longitudeDegrees!!

                continue
            }

            bLocation.latitude = location.latitudeDegrees!!
            bLocation.longitude = location.longitudeDegrees!!

            distance += aLocation.distanceTo(bLocation)

            aLocation.latitude = bLocation.latitude
            aLocation.longitude = bLocation.longitude
        }

        return distance
    }
}