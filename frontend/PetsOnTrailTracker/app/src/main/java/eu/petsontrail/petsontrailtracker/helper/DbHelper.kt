package eu.petsontrail.petsontrailtracker.helper

import android.content.Context
import androidx.room.Room
import eu.petsontrail.petsontrailtracker.data.AppDatabase

class DbHelper {
    fun InitializeDatabase(context: Context) : AppDatabase
    {
        val db: AppDatabase = Room.databaseBuilder(
            context,
            AppDatabase::class.java, "petsOnTrailTracker_dbv2"
        )
        .build()

        return db
    }
}