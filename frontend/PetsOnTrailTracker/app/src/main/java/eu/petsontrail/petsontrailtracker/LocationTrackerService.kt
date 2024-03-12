package eu.petsontrail.petsontrailtracker

import android.Manifest
import android.app.Notification
import android.app.Notification.EXTRA_NOTIFICATION_ID
import android.app.NotificationChannel
import android.app.NotificationManager
import android.app.PendingIntent
import android.app.Service
import android.content.Intent
import android.content.pm.PackageManager
import android.content.pm.ServiceInfo
import android.os.Build
import android.os.IBinder
import android.os.Looper
import android.util.Log
import android.widget.Toast
import androidx.annotation.RequiresApi
import androidx.core.app.ActivityCompat
import androidx.core.app.NotificationCompat
import androidx.core.app.ServiceCompat
import androidx.room.Room
import com.google.android.gms.location.FusedLocationProviderClient
import com.google.android.gms.location.LocationCallback
import com.google.android.gms.location.LocationRequest
import com.google.android.gms.location.LocationResult
import com.google.android.gms.location.LocationServices
import com.google.android.gms.location.Priority
import com.google.android.gms.tasks.CancellationTokenSource
import eu.petsontrail.petsontrailtracker.data.AppDatabase
import eu.petsontrail.petsontrailtracker.mapper.toLocationDto
import java.util.UUID
import kotlinx.coroutines.*

class LocationTrackerService : Service() {
    private lateinit var locationClient: FusedLocationProviderClient
    private lateinit var locationCallback: LocationCallback
    private lateinit var notificationBuilder: NotificationCompat.Builder
    private lateinit var notificationChannel: NotificationChannel
    private lateinit var notification: Notification
    private lateinit var notificationManager: NotificationManager

    // private lateinit var locationUpdateListener: LocationUpdateListener

    private lateinit var db: AppDatabase
    private lateinit var currentActivityId: UUID

    public fun setLocationUpdateListener(listener: LocationUpdateListener) {
        // locationUpdateListener = listener
    }

    override fun onBind(p0: Intent?): IBinder? {
        return null
    }

    @RequiresApi(Build.VERSION_CODES.O)
    override fun onCreate() {
        super.onCreate()

        val db = Room.databaseBuilder(
            applicationContext,
            AppDatabase::class.java, "petsOnTrailTracker_db"
        ).build()

        currentActivityId = UUID.randomUUID()

        locationCallback = object : LocationCallback() {
            override fun onLocationResult(locationResult: LocationResult) {
                for (location in locationResult.locations) {
                    Log.d(
                        "Position",
                        "Current Location = [lat : ${location.latitude}, lng : ${location.longitude}]")

                    var message = "[lat : ${location.latitude}, lng : ${location.longitude}]"
                    notificationBuilder.setContentText(message);
                    notificationManager.notify(100, notificationBuilder.build())

                    runBlocking {
                        db.locationDao().insertOne(location.toLocationDto(currentActivityId))
                    }
                }
            }
        }

        startForeground()
    }

    @RequiresApi(Build.VERSION_CODES.O)
    private fun startForeground() {
        if (ActivityCompat.checkSelfPermission(
                this,
                Manifest.permission.ACCESS_FINE_LOCATION
            ) != PackageManager.PERMISSION_GRANTED && ActivityCompat.checkSelfPermission(
                this,
                Manifest.permission.ACCESS_COARSE_LOCATION
            ) != PackageManager.PERMISSION_GRANTED
        ) {
            // TODO: Consider calling
            //    ActivityCompat#requestPermissions
            // here to request the missing permissions, and then overriding
            //   public void onRequestPermissionsResult(int requestCode, String[] permissions,
            //                                          int[] grantResults)
            // to handle the case where the user grants the permission. See the documentation
            // for ActivityCompat#requestPermissions for more details.
            return
        }

        notificationChannel = NotificationChannel(
            "CHANNEL_ID",
            "PetsOnTrailTrackerChannel",
            NotificationManager.IMPORTANCE_DEFAULT
        )
        notificationChannel.description = "PetsOnTrail Tracker channel for foreground service notification"

        notificationManager = getSystemService<NotificationManager>(NotificationManager::class.java)
        notificationManager.createNotificationChannel(notificationChannel)

        val intent = Intent(this, MainActivity::class.java).apply {
            flags = Intent.FLAG_ACTIVITY_NEW_TASK or Intent.FLAG_ACTIVITY_CLEAR_TASK
        }
        val mainActivityIntent: PendingIntent = PendingIntent.getActivity(this, 0, intent, PendingIntent.FLAG_IMMUTABLE)



        val snoozeIntent = Intent(this, LocationTrackerService::class.java).apply {
            action = "snooze"
            putExtra(EXTRA_NOTIFICATION_ID, 0)
        }
        val snoozePendingIntent: PendingIntent =
            PendingIntent.getBroadcast(this, 0, snoozeIntent, PendingIntent.FLAG_IMMUTABLE)

        notificationBuilder = NotificationCompat.Builder(this, "CHANNEL_ID")
            .setSmallIcon(R.drawable.ic_notifications_black_24dp)
            .setContentTitle("PetsOnTrail Tracker")
            .setContentText("Position: ???")
            .setPriority(NotificationCompat.PRIORITY_DEFAULT)
            .setContentIntent(mainActivityIntent)
            .addAction(R.drawable.ic_launcher_foreground, getString(R.string.start_tracking), snoozePendingIntent)
            .addAction(R.drawable.ic_launcher_foreground, getString(R.string.start_app), mainActivityIntent)
            .setAutoCancel(true)

        notification = notificationBuilder.build()

        ServiceCompat.startForeground(
            /* service = */ this,
            /* id = */ 100, // Cannot be 0
            /* notification = */ notification,
            /* foregroundServiceType = */
            if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.R) {
                ServiceInfo.FOREGROUND_SERVICE_TYPE_LOCATION
            } else {
                0
            },
        )
    }

    @RequiresApi(Build.VERSION_CODES.O)
    override fun onStartCommand(intent: Intent?, flags: Int, startId: Int): Int {
        val name=intent?.getStringExtra("name")
        Toast.makeText(
            applicationContext, "Service has started running in the background",
            Toast.LENGTH_SHORT
        ).show()
        if (name != null) {
            Log.d("Service Name",name)
        }
        Log.d("Service Status","Starting Service")

        locationClient = LocationServices.getFusedLocationProviderClient(applicationContext)

        getLocation()

        return START_STICKY
    }

    fun getLocation() {
        var locationRequest: LocationRequest
        locationRequest = LocationRequest.Builder(Priority.PRIORITY_HIGH_ACCURACY, 1000).build()

        if (ActivityCompat.checkSelfPermission(
                this,
                Manifest.permission.ACCESS_FINE_LOCATION
            ) != PackageManager.PERMISSION_GRANTED && ActivityCompat.checkSelfPermission(
                this,
                Manifest.permission.ACCESS_COARSE_LOCATION
            ) != PackageManager.PERMISSION_GRANTED
        ) {
            // TODO: Consider calling
            //    ActivityCompat#requestPermissions
            // here to request the missing permissions, and then overriding
            //   public void onRequestPermissionsResult(int requestCode, String[] permissions,
            //                                          int[] grantResults)
            // to handle the case where the user grants the permission. See the documentation
            // for ActivityCompat#requestPermissions for more details.
            return
        }


        locationClient.getCurrentLocation(
            Priority.PRIORITY_HIGH_ACCURACY, CancellationTokenSource().token
        ).addOnSuccessListener { location ->
            location?.let {
                Log.d(
                    "Position",
                    "Current Location = [lat : ${location.latitude}, lng : ${location.longitude}]",
                )

                locationClient.requestLocationUpdates(locationRequest,
                    locationCallback,
                    Looper.getMainLooper())
            }
        }
    }

    override fun stopService(name: Intent?): Boolean {
        Log.d("Stopping","Stopping Service")

        return super.stopService(name)
    }

    override fun onDestroy() {
        Toast.makeText(
            applicationContext, "Service execution completed",
            Toast.LENGTH_SHORT
        ).show()
        Log.d("Stopped","Service Stopped")
        super.onDestroy()
    }
}