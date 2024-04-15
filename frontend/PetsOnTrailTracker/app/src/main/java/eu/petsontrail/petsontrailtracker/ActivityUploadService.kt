package eu.petsontrail.petsontrailtracker

import android.app.Service
import android.content.Intent
import android.os.Build
import android.os.IBinder
import androidx.annotation.RequiresApi
import com.google.gson.Gson
import eu.petsontrail.petsontrailtracker.data.ActivityDto
import eu.petsontrail.petsontrailtracker.data.AppDatabase
import eu.petsontrail.petsontrailtracker.data.LocationDto
import eu.petsontrail.petsontrailtracker.data.PetDto
import eu.petsontrail.petsontrailtracker.dto.CreateOrUpdateActivityDto
import eu.petsontrail.petsontrailtracker.dto.CreateOrUpdateActivityPetDto
import eu.petsontrail.petsontrailtracker.dto.CreateOrUpdateActivityPositionDto
import eu.petsontrail.petsontrailtracker.helper.DbHelper
import kotlinx.coroutines.runBlocking
import okhttp3.OkHttpClient
import okhttp3.Request
import okhttp3.RequestBody.Companion.toRequestBody
import java.io.IOException
import java.time.Instant
import java.time.LocalDateTime
import java.time.ZoneId
import java.util.UUID


class ActivityUploadService : Service() {
    private lateinit var db: AppDatabase
    private val client = OkHttpClient()
    private val createOrUpdateUrl = "https://petsontrail.eu:3443/api/activities/create"

    override fun onBind(p0: Intent?): IBinder? {
        return null
    }

    override fun onCreate() {
        super.onCreate()

        db = DbHelper().InitializeDatabase(applicationContext)

        runBlocking {
            var activitiesToSynchronize = db.activityDao().getActivitiesToSynchronize()

            for (activity in activitiesToSynchronize) {
                if (activity.isSynchronized == false) {
                    CreateOrUpdateActivity(activity)
                }
            }
        }
    }

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

            var gson = Gson()
            var json = gson.toJson(MapActivity(activity, pets, positions))

            val request: Request = Request.Builder()
                .url(createOrUpdateUrl) //This adds the token to the header.
                .addHeader("Authorization", "Bearer $token")
                .post(json.toRequestBody())
                .build()

            client.newCall(request).execute().use { response ->
                if (!response.isSuccessful) {
                    throw IOException("Unexpected code $response")
                }
                System.out.println("Server: " + response.header("anykey"))
            }
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
                birthDate = petBirthDate
            ))
        }

        for (position in positions) {
            val instant = Instant.ofEpochSecond(position.time)
            val zoneId = ZoneId.systemDefault()
            val time = instant.atZone(zoneId).toLocalDateTime()

            activityPositions.add(CreateOrUpdateActivityPositionDto(
                id = position.uid,
                time =  time,
                latitude = position.latitudeDegrees,
                longitude = position.longitudeDegrees,
                altitude = position.altitudeMeters,
                accuracy = position.horizontalAccuracyMeters,
                course = null,
                note =  "",
                photoUris = null
            ))
        }

        var activityStart: LocalDateTime? = null
        var activityEnd: LocalDateTime? = null
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
            start = activityStart,
            end = activityEnd,
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