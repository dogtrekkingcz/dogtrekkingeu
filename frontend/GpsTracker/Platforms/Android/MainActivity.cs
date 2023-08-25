using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using GpsTracker.Platforms.Android.Services;
using GpsTracker.Services;

namespace GpsTracker;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true,
    ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode |
                           ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
	public const int ServiceNotificationId = 1;

	
	private bool _isServiceRunning = false;
	
	
	protected override void OnCreate(Bundle savedInstanceState)
	{
		base.OnCreate(savedInstanceState);

		ServiceHelper.OnStartRequest += StartForegroundServiceHandler;
		ServiceHelper.OnStopRequest += StopForegroundServiceHandler;
	}
	
	protected override void OnSaveInstanceState(Bundle outState) {
		//No call for super(). Bug on API Level > 11.
	}

	private void StartForegroundServiceHandler()
	{
		if (!_isServiceRunning)
		{
			// there is a need to request to use the GPS in main thread if not accepted yet
			GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
			var cancelTokenSource = new CancellationTokenSource();

			Location location = null;
			var result = Task.Run(
					async () => location = await Geolocation.Default.GetLocationAsync(request, cancelTokenSource.Token))
				.Result;
			
			ServiceHelper.ShouldItRun = true;
			
			var intent = new Intent(ServiceHelper.Context, typeof(PositionService));
			ServiceHelper.Context.StartForegroundService(intent);
			_isServiceRunning = true;
		}
	}

	private void StopForegroundServiceHandler()
	{
		if (_isServiceRunning)
		{
			ServiceHelper.ShouldItRun = false;
			
			var intent = new Intent(ServiceHelper.Context, typeof(PositionService));
			ServiceHelper.Context.StopService(intent);
			
			_isServiceRunning = false;
		}
	}
}