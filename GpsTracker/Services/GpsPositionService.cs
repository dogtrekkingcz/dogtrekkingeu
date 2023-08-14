namespace GpsTracker.Services;

internal class GpsPositionService : IGpsPositionService
{
    private CancellationTokenSource _cancelTokenSource;
    private bool _isCheckingLocation;

    private object _mutex = new();
    private IGpsPositionService.PositionDto _currentPosition = new();

    public event Action OnChange;
    private void NotifyOnChangeEvent() => OnChange?.Invoke();

    public IGpsPositionService.PositionDto CurrentPosition
    {
        get
        {
            lock (_mutex)
            {
                return _currentPosition;
            }
        }
        set
        {
            lock (_mutex)
            {
                _currentPosition = value;
            }
        }
    }
    
    public async Task<IGpsPositionService.PositionDto> GetCachedLocationAsync()
    {
        try
        {
            Location location = await Geolocation.Default.GetLastKnownLocationAsync();

            if (location != null)
            {
                CurrentPosition = new IGpsPositionService.PositionDto()
                {
                    Latitude = location.Latitude,
                    Longitude = location.Longitude,
                    Altitude = location.Altitude ?? double.NaN,
                    Accuracy = location.Accuracy ?? double.NaN,
                    Time = DateTimeOffset.Now
                };
                
                NotifyOnChangeEvent();
            }
        }
        catch (FeatureNotSupportedException fnsEx)
        {
            // Handle not supported on device exception
        }
        catch (FeatureNotEnabledException fneEx)
        {
            // Handle not enabled on device exception
        }
        catch (PermissionException pEx)
        {
            // Handle permission exception
        }
        catch (Exception ex)
        {
            // Unable to get location
        }

        return CurrentPosition;
    }
    
    public async Task<IGpsPositionService.PositionDto> GetCurrentLocationAsync()
    {
        try
        {
            _isCheckingLocation = true;

            GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));

            _cancelTokenSource = new CancellationTokenSource();

            Location location = await Geolocation.Default.GetLocationAsync(request, _cancelTokenSource.Token);

            if (location != null)
            {
                CurrentPosition = new IGpsPositionService.PositionDto()
                {
                    Latitude = location.Latitude,
                    Longitude = location.Longitude,
                    Altitude = location.Altitude ?? double.NaN,
                    Accuracy = location.Accuracy ?? double.NaN,
                    Time = DateTimeOffset.Now
                };
                
                NotifyOnChangeEvent();
            }
        }
        // Catch one of the following exceptions:
        //   FeatureNotSupportedException
        //   FeatureNotEnabledException
        //   PermissionException
        catch (Exception ex)
        {
            // Unable to get location
        }
        finally
        {
            _isCheckingLocation = false;
        }

        return CurrentPosition;
    }

    public void CancelRequest()
    {
        if (_isCheckingLocation && _cancelTokenSource != null && _cancelTokenSource.IsCancellationRequested == false)
            _cancelTokenSource.Cancel();
    }
}