package eu.petsontrail.tracker.db
import androidx.room.AutoMigration
import androidx.room.Database
import androidx.room.RoomDatabase
import eu.petsontrail.tracker.db.dao.ActivityDao
import eu.petsontrail.tracker.db.dao.ActivityPetDao
import eu.petsontrail.tracker.db.dao.LocationDao
import eu.petsontrail.tracker.db.dao.PetGroupDao
import eu.petsontrail.tracker.db.dao.PetDao
import eu.petsontrail.tracker.db.dao.UserSettingsDao
import eu.petsontrail.tracker.db.model.ActivityDto
import eu.petsontrail.tracker.db.model.ActivityPetsDto
import eu.petsontrail.tracker.db.model.LocationDto
import eu.petsontrail.tracker.db.model.PetDto
import eu.petsontrail.tracker.db.model.PetGroupDto
import eu.petsontrail.tracker.db.model.UserSettingsDto

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
        // AutoMigration ( from = 1, to = 2 )
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
        public const val DatabaseName = "PetsOnTrail.DB.v2"
        public const val LATEST_VERSION = 1
    }
}