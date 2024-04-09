package eu.petsontrail.petsontrailtracker.data

import androidx.room.AutoMigration
import androidx.room.Database
import androidx.room.RoomDatabase
import eu.petsontrail.petsontrailtracker.dao.ActivityDao
import eu.petsontrail.petsontrailtracker.dao.ActivityPetDao
import eu.petsontrail.petsontrailtracker.dao.LocationDao
import eu.petsontrail.petsontrailtracker.dao.PetGroupDao
import eu.petsontrail.petsontrailtracker.dao.PetDao
import eu.petsontrail.petsontrailtracker.dao.UserSettingsDao

@Database(
    version = AppDatabase.LATEST_VERSION,
    entities = [
        ActivityDto::class,
        LocationDto::class,
        PetGroupDto::class,
        PetDto::class,
        ActivityPetsDto::class,
        UserSettingsDto::class
    ],
    autoMigrations = [
        AutoMigration ( from = 1, to = 2 ),
        AutoMigration ( from = 2, to = 3 )
    ],
    exportSchema = true)
abstract class AppDatabase : RoomDatabase() {

    abstract fun activityDao(): ActivityDao

    abstract fun locationDao(): LocationDao

    abstract fun petGroupDao(): PetGroupDao

    abstract fun petDao(): PetDao

    abstract fun activityPetsDao(): ActivityPetDao

    abstract fun userSettingsDao(): UserSettingsDao

    companion object {
        public const val DatabaseName = "PetsOnTrail.DB.v1"
        public const val LATEST_VERSION = 3
    }
}