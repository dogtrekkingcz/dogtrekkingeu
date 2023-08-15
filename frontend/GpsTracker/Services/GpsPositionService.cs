using System;
using System.Threading;
using System.Threading.Tasks;
using GpsTracker.Services.Storage;
using MapsterMapper;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Devices.Sensors;

namespace GpsTracker.Services;

internal class GpsPositionService : IGpsPositionService
{
    private readonly PositionHistoryService _positionHistoryService;
    private readonly IMapper _mapper;
    
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

    public GpsPositionService(IMapper mapper, PositionHistoryService positionHistoryService)
    {
        _mapper = mapper;
        _positionHistoryService = positionHistoryService;
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

                await _positionHistoryService.SaveItemAsync(
                    _mapper.Map<PositionHistoryService.PositionDto>(CurrentPosition) with
                    {
                        Id = 0
                    });
                
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
                
                await _positionHistoryService.SaveItemAsync(
                    _mapper.Map<PositionHistoryService.PositionDto>(CurrentPosition) with
                    {
                        Id = 0
                    });
                
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