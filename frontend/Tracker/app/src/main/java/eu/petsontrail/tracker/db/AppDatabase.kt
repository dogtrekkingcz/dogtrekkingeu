package eu.petsontrail.tracker.db
import android.content.Context
import android.util.Log
import androidx.room.AutoMigration
import androidx.room.Database
import androidx.room.Room
import androidx.room.RoomDatabase
import androidx.sqlite.db.SupportSQLiteDatabase
import eu.petsontrail.tracker.db.dao.ActivityDao
import eu.petsontrail.tracker.db.dao.ActivityPetDao
import eu.petsontrail.tracker.db.dao.LocationDao
import eu.petsontrail.tracker.db.dao.PetGroupDao
import eu.petsontrail.tracker.db.dao.PetDao
import eu.petsontrail.tracker.db.dao.PreparingActivityDao
import eu.petsontrail.tracker.db.dao.UserSettingsDao
import eu.petsontrail.tracker.db.model.ActivityDto
import eu.petsontrail.tracker.db.model.ActivityPetsDto
import eu.petsontrail.tracker.db.model.LocationDto
import eu.petsontrail.tracker.db.model.PetDto
import eu.petsontrail.tracker.db.model.PetGroupDto
import eu.petsontrail.tracker.db.model.PreparingActivityDto
import eu.petsontrail.tracker.db.model.UserSettingsDto
import kotlinx.coroutines.CoroutineScope
import kotlinx.coroutines.launch

@Database(
    version = AppDatabase.LATEST_VERSION,
    entities = [
        ActivityDto::class,
        LocationDto::class,
        PetGroupDto::class,
        PetDto::class,
        ActivityPetsDto::class,
        UserSettingsDto::class,
        PreparingActivityDto::class
    ],
    autoMigrations = [
        AutoMigration ( from = 1, to = 2 )
    ],
    exportSchema = true)
abstract class AppDatabase : RoomDatabase() {

    abstract fun preparingActivityDao(): PreparingActivityDao

    abstract fun activityDao(): ActivityDao

    abstract fun locationDao(): LocationDao

    abstract fun petGroupDao(): PetGroupDao

    abstract fun petDao(): PetDao

    abstract fun activityPetsDao(): ActivityPetDao

    abstract fun userSettingsDao(): UserSettingsDao

    companion object {
        public const val DatabaseName = "PetsOnTrail.DB.v2"
        public const val LATEST_VERSION = 2
        private var _activity: ActivityDao? = null
        private var _location: LocationDao? = null

        @Volatile
        private var INSTANCE: AppDatabase? = null

        fun getDatabase(context: Context, scope: CoroutineScope): AppDatabase {
            val tempInstance = INSTANCE
            if (tempInstance != null) {
                return tempInstance
            }

            synchronized(this) {
                val instance = Room.databaseBuilder(
                    context.applicationContext,
                    AppDatabase::class.java,
                    DatabaseName
                ).addCallback(AppDatabaseCallback(scope)).build()

                INSTANCE = instance

                Log.d("AppDatabase", "Database created")
                _activity = instance.activityDao()
                _location = instance.locationDao()

                return instance
            }
        }

        fun getActivityDao(context: Context, scope: CoroutineScope): ActivityDao {
            if (_activity == null) {
                getDatabase(context, scope)
            }

            return _activity!!
        }

        fun getLocationDao(context: Context, scope: CoroutineScope): LocationDao {
            if (_location == null) {
                getDatabase(context, scope)
            }

            return _location!!
        }
    }

    private class AppDatabaseCallback(
        private val scope: CoroutineScope) : RoomDatabase.Callback() {
        override fun onOpen(db: SupportSQLiteDatabase) {
            super.onOpen(db)

            INSTANCE?.let { database ->
                scope.launch {
                    populateDatabase(database.activityDao())
                    populateDatabase(database.locationDao())
                    populateDatabase(database.petGroupDao())
                    populateDatabase(database.petDao())
                    populateDatabase(database.activityPetsDao())
                    populateDatabase(database.userSettingsDao())
                    populateDatabase(database.preparingActivityDao())
                }
            }
        }

        suspend fun populateDatabase(dao: ActivityDao) {
            // dao.deleteAll()
        }
        suspend fun populateDatabase(dao: LocationDao) {
            // dao.deleteAll()
        }
        suspend fun populateDatabase(dao: PetGroupDao) {
            // dao.deleteAll()
        }
        suspend fun populateDatabase(dao: PetDao) {
            // dao.deleteAll()
        }
        suspend fun populateDatabase(dao: ActivityPetDao) {
            // dao.deleteAll()
        }
        suspend fun populateDatabase(dao: UserSettingsDao) {
            // dao.deleteAll()
        }
        suspend fun populateDatabase(dao: PreparingActivityDao) {
            // dao.deleteAll()
        }
    }
}