package eu.petsontrail.tracker.services

import activities.ActivitiesGrpc
import addpoints.AddPointsRequestOuterClass
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
import com.google.protobuf.Timestamp
import createactivity.CreateActivityRequestOuterClass
import createactivity.CreateActivityRequestOuterClass.CreateActivityRequest
import eu.petsontrail.tracker.Constants
import eu.petsontrail.tracker.MainActivity
import eu.petsontrail.tracker.R
import eu.petsontrail.tracker.db.AppDatabase
import eu.petsontrail.tracker.db.model.ActivityDto
import eu.petsontrail.tracker.db.model.LocationDto
import eu.petsontrail.tracker.db.model.PetDto
import io.grpc.ManagedChannel
import io.grpc.ManagedChannelBuilder
import kotlinx.coroutines.runBlocking
import java.time.Instant
import java.time.LocalDateTime
import java.time.ZoneId
import java.util.UUID


class ActivityUploadService : Service() {
    private val TAG: String = "ActivityUploadService"
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

        runBlocking {
            var activitiesToSynchronize = AppDatabase.getDatabase(this@ActivityUploadService, this).activityDao().getActivitiesToSynchronize()

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
            val token = AppDatabase.getDatabase(this@ActivityUploadService, this).userSettingsDao().getAccessToken()
            val activityPets = AppDatabase.getDatabase(this@ActivityUploadService, this).activityPetsDao().loadAllByActivityId(activity.uid)
            val positions = AppDatabase.getDatabase(this@ActivityUploadService, this).locationDao().findByActivityId(activity.uid)

            val activityPetsIds = ArrayList<UUID>()
            for (ap in activityPets) {
                activityPetsIds.add(ap.petId)
            }
            val pets = AppDatabase.getDatabase(this@ActivityUploadService, this).petDao().loadAllByIds(activityPetsIds.toTypedArray())

            channel = ManagedChannelBuilder
                        .forTarget("dns:///petsontrail.eu:4443")
                        .build()
            var client = ActivitiesGrpc
                .newBlockingStub(channel)
                .withCallCredentials(AuthenticationCallCredentials(token))

            var requestBuilder: CreateActivityRequest.Builder? = CreateActivityRequest.newBuilder()
                .setId(activity.uid.toString())
                .setActionId(Constants.UUID_EMPTY)
                .setRaceId(Constants.UUID_EMPTY)
                .setCategoryId(Constants.UUID_EMPTY)
                .setIsPublic(true)
                .setDescription(activity.description)
                .setName(activity.name)
                .setType(activity.type.toString())
                .addAllPets(pets.map { pet ->

                    var petDtoBuilder = CreateActivityRequestOuterClass.PetDto.newBuilder()
                        .setId(pet.uid.toString())
                        .setChip(pet.chip)
                        .setName(pet.name)
                        .setBreed(pet.breed)
                        .setColor(pet.color)
                        .setKennel(pet.kennel)

                    if (pet.birthday != null)
                        petDtoBuilder.setBirthDate(Timestamp.newBuilder().setSeconds(pet.birthday))

                    petDtoBuilder
                        .build()
                })

            if (activity.start != null) {
                requestBuilder?.setStart(Timestamp.newBuilder().setSeconds(activity.start!!))
            }

            if (activity.end != null) {
                requestBuilder?.setEnd(Timestamp.newBuilder().setSeconds(activity.end!!))
            }

            var request = requestBuilder?.build()
            var response = client.createActivity(request)

            if (response != null) {
                Log.d("Service status", "Activity created")

                for (i in 0..positions.size step 100) {
                    var positionsChunk = positions.subList(i, Math.min(positions.size, i + 100))

                    if (positionsChunk.isEmpty())
                        break

                    var addPointsRequestBuilder: AddPointsRequestOuterClass.AddPointsRequest.Builder? = AddPointsRequestOuterClass.AddPointsRequest.newBuilder()
                    addPointsRequestBuilder
                        ?.setActivityId(activity.uid.toString())
                        ?.addAllPoints(positionsChunk.map { position ->
                            var positionDtoBuilder = AddPointsRequestOuterClass.PointDto.newBuilder()
                                .setId(position.uid.toString())
                                .setTime(Timestamp.newBuilder().setSeconds(position.time))
                                .setLatitude(position.latitudeDegrees!!)
                                .setLongitude(position.longitudeDegrees!!)

                            if (position.altitudeMeters != null)
                                positionDtoBuilder.setAltitude(position.altitudeMeters!!)

                            if (position.horizontalAccuracyMeters != null)
                                positionDtoBuilder.setAccuracy(position.horizontalAccuracyMeters!!.toDouble())

                            if (position.bearingDegrees != null)
                                positionDtoBuilder.setCourse(position.bearingDegrees!!.toDouble())

                            if (position.note != null)
                                positionDtoBuilder.setNote(position.note)

                            positionDtoBuilder.build()
                        })
                    client.addPoints(addPointsRequestBuilder?.build())
                }
            }

            channel.shutdownNow()
        }
    }
}