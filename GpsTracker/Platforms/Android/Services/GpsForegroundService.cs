using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using GpsTracker.Services;


namespace GpsTracker;

[Service(ForegroundServiceType = Android.Content.PM.ForegroundService.TypeDataSync)]
public class GpsForegroundService : Service, IFgService
{
    private bool Started { get; set; } = false;
    private IGpsPositionService _gpsPositionService => ServiceHelper.GetService<IGpsPositionService>();
    
    public double Latitude { get; set; } = Double.NaN;
    public double Longitude { get; set; } = Double.NaN;
    public double Altitude { get; set; } = double.NaN;
    public double Accuracy { get; set; } = Double.NaN;
    
    public override IBinder OnBind(Intent intent)
    {
        throw new NotImplementedException();
    }
    
    [return: GeneratedEnum]
    public override StartCommandResult OnStartCommand(Intent intent, [GeneratedEnum] StartCommandFlags flags, int startId)
    {
        if (intent.Action == "START_SERVICE")
        {
            RegisterNotification();
        }
        else if (intent.Action == "STOP_SERVICE")
        {
            StopForeground(true);
            StopSelfResult(startId);
        }

        Started = true;
        SimulateLocationTracking();
        
        return StartCommandResult.NotSticky;
    }

    async void SimulateLocationTracking()
    {
        while (Started)
        {
            await _gpsPositionService.GetCurrentLocationAsync();
            
            await Task.Delay(10000);
        }
    }
    
    public void Start()
    {
        Intent startService = new Intent(MainActivity.ActivityCurrent, typeof(GpsForegroundService));
        startService.SetAction("START_SERVICE");
        
        MainActivity.ActivityCurrent.StartService(startService);
    }

    public void Stop()
    {
        Started = false;
        
        Intent stopIntent = new Intent(MainActivity.ActivityCurrent, this.Class);
        stopIntent.SetAction("STOP_SERVICE");
        
        MainActivity.ActivityCurrent.StartService(stopIntent);
    }

    private void RegisterNotification()
    {
        NotificationChannel channel = new NotificationChannel("PetsOnTrail - GPS tracker", "PetsOnTrail - GPS tracker is running", NotificationImportance.Max);
        NotificationManager manager = (NotificationManager)MainActivity.ActivityCurrent.GetSystemService(Context.NotificationService);
        manager.CreateNotificationChannel(channel);
        
        Notification notification = new Notification.Builder(this, "PetsOnTrail - GPS tracker")
            .SetContentTitle("Service is running")
            .SetSmallIcon(Microsoft.Maui.Resource.Drawable.abc_ab_share_pack_mtrl_alpha)
            .SetOngoing(true)
            .Build();

        StartForeground(100, notification);
    }
}