using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using AndroidX.Core.App;
using GpsTracker.Services;
using GpsTracker.Services.Storage;

namespace GpsTracker.Platforms.Android.Services;

// https://learn.microsoft.com/en-us/xamarin/android/app-fundamentals/services/out-of-process-services#create-a-service-that-runs-in-a-separate-process

// TODO - check after any months ...
// Currently there is an issue with Xamarin.Android where the service
// will crash on startup when attempting to run it in it's own process. 
// See https://bugzilla.xamarin.com/show_bug.cgi?id=51940
// [Service(
//     Name = "eu.petsontrail.gpstracker",
//     ForegroundServiceType = ForegroundService.TypeLocation, 
//     Exported = true, 
//     Process = ":positionservice_process")]
[Service(
    Name = "eu.petsontrail.gpstracker",
    ForegroundServiceType = ForegroundService.TypeLocation)]
public class PositionService : Service
{
    public const string ServiceChannelId = "ForegroundServiceChannel";
    private NotificationManager _notificationManager;
    private CancellationTokenSource _cancelTokenSource;
    private PositionHistoryService _positionHistoryService = new();

    public override void OnCreate()
    {
        base.OnCreate();
        _notificationManager = (NotificationManager)GetSystemService(NotificationService);
    }

    public override IBinder OnBind(Intent intent)
    {
        return null;
    }

    public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
    {
        CreateNotificationChannel();

        var notificationIntent = new Intent(this, typeof(MainActivity));
        var pendingIntent = PendingIntent.GetActivity(this, 0, notificationIntent, PendingIntentFlags.Immutable);

        var notification = new NotificationCompat.Builder(this, ServiceChannelId)
            .SetContentTitle("PetsOnTrail Tracking")
            .SetContentText("Is running")
            .SetSmallIcon(Resource.Mipmap.appicon_foreground)
            .SetContentIntent(pendingIntent)
            .Build();

        StartForeground(MainActivity.ServiceNotificationId, notification);
        
        Task.Run(async () =>
        {
            while (ServiceHelper.ShouldItRun)
            {
                var location = await GetCurrentLocation();
                
                await _positionHistoryService.SaveItemAsync(new PositionHistoryService.PositionDto()
                {
                    Latitude = location.Latitude,
                    Longitude = location.Longitude,
                    Altitude = location.Altitude ?? double.NaN,
                    Accuracy = location.Accuracy ?? double.NaN,
                    Time = location.Timestamp,
                    Id = 0,
                    ActionId = Guid.Empty
                });

                try
                {
                    ServiceHelper.LocationChanged(location);
                }
                catch (Exception ex)
                {
                    ;
                }
                
                
                
                await Task.Delay(1000);
            }

            StopForeground(true);
        });

        return StartCommandResult.Sticky;
    }

    private void CreateNotificationChannel()
    {
        if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
        {
            var channel = new NotificationChannel(ServiceChannelId, "Foreground Service Channel", NotificationImportance.Default);
            _notificationManager.CreateNotificationChannel(channel);
        }
    }
    
    private async Task<Location> GetCurrentLocation()
    {
        Location ret = null;
        try
        {
            GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
                
            _cancelTokenSource = new CancellationTokenSource();

            ret = await Geolocation.Default.GetLocationAsync(request, _cancelTokenSource.Token);
        }
        catch (Exception ex)
        {
            ;
        }

        return ret;
    }
}