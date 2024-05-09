package eu.petsontrail.tracker.services

import actions.ActionsGrpc
import activities.ActivitiesGrpc
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
import android.util.Log
import android.widget.Toast
import androidx.annotation.RequiresApi
import androidx.core.app.ActivityCompat
import androidx.core.app.NotificationCompat
import androidx.core.app.ServiceCompat
import com.google.protobuf.Empty
import createactivity.CreateActivityRequestOuterClass.CreateActivityRequest
import eu.petsontrail.tracker.MainActivity
import eu.petsontrail.tracker.R
import eu.petsontrail.tracker.db.AppDatabase
import eu.petsontrail.tracker.db.DbHelper
import eu.petsontrail.tracker.db.model.ActivityDto
import eu.petsontrail.tracker.db.model.LocationDto
import eu.petsontrail.tracker.db.model.PetDto
import io.grpc.ManagedChannel
import io.grpc.ManagedChannelBuilder
import kotlinx.coroutines.runBlocking
import java.lang.ref.WeakReference
import java.time.Instant
import java.time.LocalDateTime
import java.time.ZoneId
import java.util.UUID


class ActivityUploadService : Service() {
    private val TAG: String = "ActivityUploadService"
    private lateinit var db: AppDatabase
    private lateinit var notificationBuilder: NotificationCompat.Builder
    private lateinit var notificationChannel: NotificationChannel
    private lateinit var notification: Notification
    private lateinit var notificationManager: NotificationManager

    private lateinit var channel: ManagedChannel
    private val HOST: String = "194.182.90.15"
    private val PORT: Int = 4443

    override fun onBind(p0: Intent?): IBinder? {
        return null
    }

    @RequiresApi(Build.VERSION_CODES.O)
    override fun onCreate() {
        super.onCreate()

        startForeground()
    }

    @RequiresApi(Build.VERSION_CODES.O)
    private fun startForeground() {
        if (ActivityCompat.checkSelfPermission(
                this,
                Manifest.permission.INTERNET
            ) != PackageManager.PERMISSION_GRANTED && ActivityCompat.checkSelfPermission(
                this,
                Manifest.permission.INTERNET
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


        notificationBuilder = NotificationCompat.Builder(this, "CHANNEL_ID")
            .setSmallIcon(R.mipmap.ic_pets_in_cloud)
            .setContentTitle("PetsOnTrail Tracker")
            .setContentText("Synchronization is running")
            .setPriority(NotificationCompat.PRIORITY_DEFAULT)
            .setContentIntent(mainActivityIntent)
            .setAutoCancel(true)

        notification = notificationBuilder.build()

        ServiceCompat.startForeground(
            /* service = */ this,
            /* id = */ 100, // Cannot be 0
            /* notification = */ notification,
            /* foregroundServiceType = */
            if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.R) {
                ServiceInfo.FOREGROUND_SERVICE_TYPE_DATA_SYNC
            } else {
                0
            },
        )
    }

    @RequiresApi(Build.VERSION_CODES.O)
    override fun onStartCommand(intent: Intent?, flags: Int, startId: Int): Int {
        val name = intent?.getStringExtra("name")
        Toast.makeText(
            applicationContext, "Service has started running in the background",
            Toast.LENGTH_SHORT
        ).show()
        if (name != null) {
            Log.d("Service Name", name)
        }
        Log.d("Service Status", "Starting Service")

        db = DbHelper().InitializeDatabase(applicationContext)

        runBlocking {
            var activitiesToSynchronize = db.activityDao().getActivitiesToSynchronize()

            for (activity in activitiesToSynchronize) {
                Log.d("Service status", "Sending request to createorupdateactivity ...")
                //if (activity.isSynchronized == false) {
                    CreateOrUpdateActivity(activity)
                //}
            }
        }

        return START_STICKY
    }

    override fun stopService(name: Intent?): Boolean {
        Log.d("Stopping","Stopping Service")

        var result: Boolean = false

        return result
    }

    override fun onDestroy() {
        Toast.makeText(
            applicationContext, "Service execution completed",
            Toast.LENGTH_SHORT
        ).show()
        Log.d("Stopped","Service Stopped")
        super.onDestroy()
    }

    @RequiresApi(Build.VERSION_CODES.O)
    fun CreateOrUpdateActivity(activity: ActivityDto) {
        runBlocking {
            val token = db.userSettingsDao().getAccessToken()
            val activityPets = db.activityPetsDao().loadAllByActivityId(activity.uid)
            val positions = db.locationDao().findByActivityId(activity.uid)

            val activityPetsIds = ArrayList<UUID>()
            for (ap in activityPets) {
                activityPetsIds.add(ap.petId)
            }
            val pets = db.petDao().loadAllByIds(activityPetsIds.toTypedArray())

            channel = ManagedChannelBuilder.forTarget("dns:///petsontrail.eu:4443").build()
            var state = channel.getState(true)

            Log.d("Service status", state.toString())

            var actionsClient = ActionsGrpc.newBlockingStub(channel)

            var publicActions = actionsClient.getPublicActionsList(Empty.newBuilder().build())
            Log.d("public actions", publicActions.toString())

            var client = ActivitiesGrpc.newBlockingStub(channel)
            var request: CreateActivityRequest = CreateActivityRequest.newBuilder()
                    .setId(activity.uid.toString())
                    .setName(activity.name)
                .build()
            Log.d("Service status", "sending request")
            var resposne = client.createActivity(request)
            Log.d("Service status", "done")
        }
    }

    @RequiresApi(Build.VERSION_CODES.O)
    fun MapActivity(activity: ActivityDto, pets: List<PetDto>, positions: List<LocationDto>) : CreateOrUpdateActivityDto {
        val activityPets = ArrayList<CreateOrUpdateActivityPetDto>()
        val activityPositions = ArrayList<CreateOrUpdateActivityPositionDto>()

        for (pet in pets) {
            var petBirthDate: LocalDateTime? = null
            if (pet.birthday != null) {
                val instant = Instant.ofEpochSecond(pet.birthday)

                val zoneId = ZoneId.systemDefault()

                petBirthDate = instant.atZone(zoneId).toLocalDateTime()
            }

            activityPets.add(CreateOrUpdateActivityPetDto(
                id = pet.uid,
                chip = pet.chip,
                name = pet.name,
                breed = "", // pet.breed,
                color = "", // pet.color,
                kennel = pet.kennel,
                birthDate = petBirthDate.toString()
            ))
        }

        for (position in positions) {
            val instant = Instant.ofEpochSecond(position.time)
            val zoneId = ZoneId.systemDefault()
            val time = instant.atZone(zoneId).toLocalDateTime()

            activityPositions.add(CreateOrUpdateActivityPositionDto(
                id = position.uid,
                time =  time.toString(),
                latitude = position.latitudeDegrees,
                longitude = position.longitudeDegrees,
                altitude = position.altitudeMeters,
                accuracy = position.horizontalAccuracyMeters,
                course = null,
                note =  "",
                photoUris = null
            ))
        }

        var activityStart: LocalDateTime = LocalDateTime.now().minusYears(1)
        var activityEnd: LocalDateTime = LocalDateTime.now().plusYears(1)
        val zoneId = ZoneId.systemDefault()
        if (activity.start != null) {
            val instant = Instant.ofEpochSecond(activity.start)

            activityStart = instant.atZone(zoneId).toLocalDateTime()
        }
        if (activity.end != null) {
            val instant = Instant.ofEpochSecond(activity.end)
            activityEnd = instant.atZone(zoneId).toLocalDateTime()
        }
        val result: CreateOrUpdateActivityDto = CreateOrUpdateActivityDto(
            id = activity.uid,
            start = activityStart.toString(),
            end = activityEnd.toString(),
            description = "",
            actionId = null,
            categoryId = null,
            isPublic = true,
            name = activity.name,
            raceId = null,
            pets = activityPets.toTypedArray(),
            positions = activityPositions.toTypedArray()
        )

        return result
    }
}