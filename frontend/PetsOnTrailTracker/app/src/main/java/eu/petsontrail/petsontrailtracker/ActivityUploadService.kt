package eu.petsontrail.petsontrailtracker

import android.app.Activity
import android.app.Service
import android.content.Intent
import android.os.Build
import android.os.IBinder
import androidx.annotation.RequiresApi
import eu.petsontrail.petsontrailtracker.data.ActivityDto
import eu.petsontrail.petsontrailtracker.data.AppDatabase
import eu.petsontrail.petsontrailtracker.helper.DbHelper
import kotlinx.coroutines.runBlocking

class ActivityUploadService : Service() {
    private lateinit var db: AppDatabase

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
                    CreateActivity(activity)
                }
                else {
                    // TODO: just update it
                }
            }
        }
    }

    fun UpdateActivity(activity: ActivityDto) {
        // TODO: Update activity data - generally points
    }
    fun CreateActivity(activity: ActivityDto) {
        // TODO: create a new activity on the server
        /*


    public Guid IdActivity { get; init; } = Guid.NewGuid();

    public DateTimeOffset Created { get; init; } = DateTimeOffset.Now;

    public string Name { get; init; } = string.Empty;

    public string Description { get; init; } = string.Empty;

    public string Type { get; init; } = string.Empty;


    public List<ActivityPetDto> Pets { get; init; } = new List<ActivityPetDto>();

    public List<ActivityPointDto> Points { get; init; } = new List<ActivityPointDto>();

    public sealed record ActivityPetDto
    {
        public Guid Id { get; init; } = Guid.NewGuid();

        public string? Chip { get; init; }

        public string? Name { get; init; }

        public string? Breed { get; init; }

        public string? Color { get; init; }

        public string Kennel { get; init; }

        public DateTimeOffset? BirthDate { get; init; }
    }

    public sealed record ActivityPointDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public DateTimeOffset Time { get; set; } = DateTimeOffset.Now;

        public double Latitude { get; set; } = double.NaN;

        public double Longitude { get; set; } = double.NaN;

        public double Altitude { get; set; } = double.NaN;

        public double Accuracy { get; set; } = double.NaN;

        public double Course { get; set; } = double.NaN;

        public string Note { get; set; } = string.Empty;

        public List<string> PhotoUris { get; set; } = new();
    }

         */
    }
}