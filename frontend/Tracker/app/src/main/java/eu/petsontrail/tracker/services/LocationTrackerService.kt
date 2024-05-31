package eu.petsontrail.tracker.services

import android.Manifest
import android.app.Notification
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
import com.google.android.gms.location.FusedLocationProviderClient
import com.google.android.gms.location.LocationCallback
import com.google.android.gms.location.LocationRequest
import com.google.android.gms.location.LocationResult
import com.google.android.gms.location.LocationServices
import com.google.android.gms.location.Priority
import com.google.android.gms.tasks.CancellationTokenSource
import com.google.android.gms.tasks.Task
import eu.petsontrail.tracker.MainActivity
import eu.petsontrail.tracker.R
import eu.petsontrail.tracker.db.model.ActivityDto
import eu.petsontrail.tracker.db.AppDatabase
import eu.petsontrail.tracker.db.toLocationDto
import kotlinx.coroutines.*
import java.time.LocalDateTime
import java.time.ZoneOffset
import java.time.format.DateTimeFormatter
import java.util.Locale
import java.util.UUID
import kotlin.properties.Delegates


class LocationTrackerService : Service() {
    private lateinit var locationClient: FusedLocationProviderClient
    private lateinit var locationCallback: LocationCallback
    private lateinit var notificationBuilder: NotificationCompat.Builder
    private lateinit var notificationChannel: NotificationChannel
    private lateinit var notification: Notification
    private lateinit var notificationManager: NotificationManager

    private var currentActivityId: UUID? = null
    private var currentActivityName: String? = null
    private var _startId by Delegates.notNull<Int>()

    override fun onBind(p0: Intent?): IBinder? {
        return null
    }

    @RequiresApi(Build.VERSION_CODES.O)
    override fun onCreate() {
        super.onCreate()

        runBlocking {
            var active = AppDatabase.getDatabase(this@LocationTrackerService, this).activityDao().getActive()

            currentActivityId = active?.uid
            currentActivityName = active?.name
        }

        locationCallback = object : LocationCallback() {
            override fun onLocationResult(locationResult: LocationResult) {
                for (location in locationResult.locations) {
                    Log.d(
                        "Position",
                        "Current LocationNN = [lat : ${location.latitude}, lng : ${location.longitude}]")

                    runBlocking {
                        if (currentActivityId == null)
                            createNewActivity()

                        AppDatabase.getDatabase(this@LocationTrackerService, this).locationDao().insertOne(location.toLocationDto(currentActivityId!!))
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


        /*
        val startTrackingIntent = Intent(this, LocationTrackerService::class.java).apply {
            action = "start-tracking"
            putExtra("method_to_call", 1001)
        }
        val startTrackingPendingIntent: PendingIntent = PendingIntent.getForegroundService(this, 0, startTrackingIntent, PendingIntent.FLAG_IMMUTABLE)
        */

        val newActivityIntent = Intent(this, LocationTrackerService::class.java).apply {
            action = "create-new-activity"
            putExtra("method_to_call", 1002)
        }
        val newActivityPendingIntent: PendingIntent = PendingIntent.getForegroundService(this, 0, newActivityIntent, PendingIntent.FLAG_IMMUTABLE)

        val closeActivityIntent = Intent(this, LocationTrackerService::class.java).apply {
            action = "close-activity"
            putExtra("method-to-call", 1003)
        }
        val closeActivityPendingIntent: PendingIntent = PendingIntent.getForegroundService(this, 0, closeActivityIntent, PendingIntent.FLAG_IMMUTABLE)


        notificationBuilder = NotificationCompat.Builder(this, "CHANNEL_ID")
            .setSmallIcon(R.mipmap.ic_pets_in_cloud)
            .setContentTitle("PetsOnTrail Tracker")
            .setPriority(NotificationCompat.PRIORITY_DEFAULT)
            .setContentIntent(mainActivityIntent)
            // .addAction(R.drawable.ic_launcher_foreground, getString(R.string.start_tracking), startTrackingPendingIntent)
            .addAction(R.drawable.ic_launcher_foreground, getString(R.string.create_new_activity), newActivityPendingIntent)
            .addAction(R.drawable.ic_launcher_foreground, "Close activity", closeActivityPendingIntent)
            //.setStyle(NotificationCompat.BigTextStyle()
            //    .bigText("Much longer text that cannot fit one line..."))
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
        _startId = startId

        val name=intent?.getStringExtra("name")
        Toast.makeText(
            applicationContext, "Service has started running in the background",
            Toast.LENGTH_SHORT
        ).show()
        if (name != null) {
            Log.d("Service Name",name)
        }
        Log.d("Service Status","Starting Service")

        // ------------------------------------------------------

        Log.d("extras:", intent?.extras.toString())

        var action = intent?.getIntExtra("method_to_call", 0)

        if (action == 1002) {
            createNewActivity()
        }
        else if (action == 1003) {
            runBlocking {
                AppDatabase.getDatabase(this@LocationTrackerService, this).activityDao().resetActiveActivities()

                prepareToStopService()
            }
        }
        else {
            Log.d("fusedLocationProvider", "getting ...")
            locationClient = LocationServices.getFusedLocationProviderClient(applicationContext)
            Log.d("fusedLocationProvider", locationClient.toString())


            getLocation()
            Log.d("fusedLocationProvider", "getLocation after")
        }

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
            Log.d("permission", "no permission for locations is configured")

            return
        }


        locationClient.getLastLocation().addOnSuccessListener { location ->
            location?.let {
                Log.d(
                    "Position",
                    "Last known location = [lat : ${location.latitude}, lng : ${location.longitude}]",
                )

                locationClient.requestLocationUpdates(locationRequest,
                    locationCallback,
                    Looper.myLooper())
            }
        }
    }

    fun prepareToStopService() {
        try {
            CancellationTokenSource().cancel()

            val voidTask: Task<Void> = locationClient.removeLocationUpdates(locationCallback)
            voidTask.addOnCompleteListener {
                if(it.isSuccessful) {
                    Log.d("Location", "stopMonitoring: removeLocationUpdates successful.")

                    ServiceCompat.stopForeground(this, ServiceCompat.STOP_FOREGROUND_REMOVE)

                    stopSelf()

                    super.stopSelfResult(_startId)

                } else {
                    Log.d("Location", "stopMonitoring: removeLocationUpdates updates unsuccessful! " + voidTask.toString())
                }
            }

            Thread.sleep(2000)
        } catch (exp: SecurityException) {
            Log.d("TAG", " Security exception while removeLocationUpdates")
        }
    }

    override fun stopService(name: Intent?): Boolean {
        Log.d("Stopping","Stopping Service")

        var result: Boolean = false

        prepareToStopService()

        return result
    }

    override fun onDestroy() {
        prepareToStopService()

        Toast.makeText(
            applicationContext, "Service execution completed",
            Toast.LENGTH_SHORT
        ).show()
        Log.d("Stopped","Service Stopped")
        super.onDestroy()
    }

    @RequiresApi(Build.VERSION_CODES.O)
    fun createNewActivity() {
        Log.d("New activity", "Creating a new activity ...")
        currentActivityId = UUID.randomUUID()

        runBlocking {
            AppDatabase.getDatabase(this@LocationTrackerService, this).activityDao().resetActiveActivities()

            var newActivity = ActivityDto(
                uid = currentActivityId!!,
                time = LocalDateTime.now().toEpochSecond(ZoneOffset.UTC),
                name = LocalDateTime.now().format(DateTimeFormatter.ofPattern("yyyy-MM-dd HH:mm:ss", Locale.ENGLISH)),
                active = 1,
                start = LocalDateTime.now().toEpochSecond(ZoneOffset.UTC),
                end = LocalDateTime.now().toEpochSecond(ZoneOffset.UTC),
                description = ""
            )

            AppDatabase.getDatabase(this@LocationTrackerService, this).activityDao().insertOne(newActivity)

            currentActivityId = AppDatabase.getDatabase(this@LocationTrackerService, this).activityDao().getActive()?.uid!!
        }
    }
}