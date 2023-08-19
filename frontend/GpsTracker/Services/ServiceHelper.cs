#if ANDROID
using Android.Content;
using Android.Provider;
#endif

namespace GpsTracker.Services;

public static class ServiceHelper {
    public static T GetService<T>() => Current.GetService<T>();
    
    public static event Action OnStartRequest;
    public static event Action OnStopRequest;
    public static event Action<Location> OnLocationChanged;

    public static bool ShouldItRun = false;

    public static string CurrentSelectedActionId { get; set; } = Guid.Empty.ToString();

    public static void Start()
    {
        ShouldItRun = true;
        
        OnStartRequest?.Invoke();
    }

    public static void Stop()
    {
        ShouldItRun = false;
        
        OnStopRequest?.Invoke();
    }

    public static void LocationChanged(Location location)
    {
        OnLocationChanged?.Invoke(location);
    }

#if ANDROID
    public static Context Context => global::Android.App.Application.Context;
#else

#endif
        
    public static IServiceProvider Current =>
            
#if WINDOWS10_0_17763_0_OR_GREATER
        MauiWinUIApplication.Current.Services;
#elif ANDROID
        MauiApplication.Current.Services;
#elif IOS || MACCATALYST
        MauiUIApplicationDelegate.Current.Services;
#else
        null;
#endif 
}