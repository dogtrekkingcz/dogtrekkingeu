package eu.petsontrail.petsontrailtracker.data

import androidx.room.AutoMigration
import androidx.room.Database
import androidx.room.RoomDatabase
import eu.petsontrail.petsontrailtracker.dao.ActivityDao
import eu.petsontrail.petsontrailtracker.dao.ActivityPetDao
import eu.petsontrail.petsontrailtracker.dao.LocationDao
import eu.petsontrail.petsontrailtracker.dao.PetGroupDao
import eu.petsontrail.petsontrailtracker.dao.PetDao

@Database(
    version = AppDatabase.LATEST_VERSION,
    entities = [
        ActivityDto::class,
        LocationDto::class,
        PetGroupDto::class,
        PetDto::class,
        ActivityPetsDto::class,
    ],
    autoMigrations = [
        AutoMigration (
            from = 1,
            to = 2
        )
    ],
    exportSchema = true)
abstract class AppDatabase : RoomDatabase() {

    abstract fun activityDao(): ActivityDao

    abstract fun locationDao(): LocationDao

    abstract fun petGroupDao(): PetGroupDao

    abstract fun petDao(): PetDao

    abstract fun activityPetsDao(): ActivityPetDao

    companion object {
        public const val DatabaseName = "PetsOnTrail.DB.v1"
        public const val LATEST_VERSION = 1
    }
}