package eu.petsontrail.petsontrailtracker

import android.location.Location

interface LocationUpdateListener {
    fun onUpdateLocation(location: Location): Int {
        return 1
    }

    fun onUpdateMultipleLocations(data: MutableList<Location>): Int {
        return data.size
    }
}