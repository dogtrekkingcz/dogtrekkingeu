package eu.petsontrail.tracker.db

import android.content.Context
import androidx.room.Room
import eu.petsontrail.tracker.db.AppDatabase

class DbHelper {
    fun InitializeDatabase(context: Context) : AppDatabase
    {
        val db: AppDatabase = Room.databaseBuilder(
            context,
            AppDatabase::class.java, AppDatabase.DatabaseName
        )
        .build()

        return db
    }
}