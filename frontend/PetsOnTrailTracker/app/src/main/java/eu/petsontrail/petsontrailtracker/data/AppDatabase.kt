package eu.petsontrail.petsontrailtracker.data

import androidx.room.Database
import androidx.room.RoomDatabase
import eu.petsontrail.petsontrailtracker.dao.ActivityDao
import eu.petsontrail.petsontrailtracker.dao.LocationDao

@Database(entities = [ActivityDto::class, LocationDto::class], version = 2)
abstract class AppDatabase : RoomDatabase() {
    abstract fun activityDao(): ActivityDao

    abstract fun locationDao(): LocationDao
}