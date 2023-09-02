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
// FROM: https://github.com/xamarin/monodroid-samples/blob/main/ApplicationFundamentals/ServiceSamples/MessengerServiceDemo/MessengerService/Service/TimestampService.cs
// https://github.com/dotnet/maui/issues/16142
// https://github.com/xamarin/xamarin-android/issues/3378
// -------
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
    private PositionHistoryService _positionHistoryService;

    public override void OnCreate()
    {
        base.OnCreate();
        _notificationManager = (NotificationManager)GetSystemService(NotificationService);
        _positionHistoryService = ServiceHelper.GetService<PositionHistoryService>();
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
            .SetSmallIcon(Resource.Drawable.abc_star_black_48dp)
            .SetContentIntent(pendingIntent)
            .Build();

        StartForeground(MainActivity.ServiceNotificationId, notification);

        Task.Run(async () => await StartServiceAsync());

        return StartCommandResult.Sticky;
    }

    private async Task StartServiceAsync()
    {
        while (ServiceHelper.ShouldItRun)
        {
            while (ServiceHelper.ShouldItRun && (ServiceHelper.LatestPositionTime >
                                                 DateTimeOffset.Now.AddSeconds((-1) *
                                                     ServiceHelper.NumberOfSecsBetweenAcquiringPosition)))
            {
                await Task.Delay(200);
            }

            var location = await GetCurrentLocation();

            if (location != null)
            {                    
                ServiceHelper.LocationChanged(location);

                ServiceHelper.LatestPositionTime = DateTimeOffset.Now;
            }

            await Task.Delay(1000);
        }

        StopForeground(true);
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