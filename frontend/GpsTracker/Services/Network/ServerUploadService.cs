using Google.Type;
using GpsTracker.Services.Storage;
using Protos.Activities.AddPoint;
using Protos.Checkpoints.AddCheckpoint;
using SharedLib.Extensions;

namespace GpsTracker.Services.Network;

public class ServerUploadService
{
    private readonly PositionHistoryService _positionHistoryService;

    public ServerUploadService(PositionHistoryService positionHistoryService)
    {
        _positionHistoryService = positionHistoryService;
    }

    public void Start()
    {
        Task.Run(async () =>
        {
            while (true) 
            {
                await CheckAndUploadNotSynchronizedEntriesAsync();

                await Task.Delay(500);
            }
        });
    }

    private async Task CheckAndUploadNotSynchronizedEntriesAsync()
    {
        NetworkAccess accessType = Connectivity.Current.NetworkAccess;
        
        if (accessType == NetworkAccess.Internet && ServiceHelper.LatestUploadTime < DateTimeOffset.Now.AddSeconds((-1) * ServiceHelper.NumberOfSecsBetweenUploadingData))
        {
            var activitiesClient = ServiceHelper.GetService<Protos.Activities.Activities.ActivitiesClient>();
            var notUploadedData = await _positionHistoryService.GetItemsNotSynchronizedAsync();
            
            foreach (var item in notUploadedData) 
            {
                await activitiesClient.addPointAsync(new AddPointRequest
                {
                    ActivityId = item.ActivityId.ToString(),
                    Time = item.Time.ToGoogleDateTime(),
                    Longitude = item.Longitude,
                    Accuracy = item.Accuracy,
                    Altitude = item.Altitude,
                    Note = item.Note,
                    Latitude = item.Latitude,
                    Course = item.Course
                });
                
                item.TimeOfSynchronizationWithServer = DateTimeOffset.Now;

                await _positionHistoryService.SaveItemAsync(item);
            }
            
            ServiceHelper.LatestUploadTime = DateTimeOffset.Now;
        }
    }
    
    public sealed record PositionDto
    {
        public Int64 Id { get; set; } = 0;

        public Guid ActivityId { get; set; } = Guid.Empty;

        public Guid ActionId { get; set; } = Guid.Empty;
        
        public DateTimeOffset? TimeOfSynchronizationWithServer { get; set; } = null;
        
        public double Latitude { get; set; } = double.NaN;

        public double Longitude { get; set; } = double.NaN;

        public double Altitude { get; set; } = double.NaN;

        public double Accuracy { get; set; } = double.NaN;

        public DateTimeOffset Time { get; set; } = DateTimeOffset.MinValue;
    }
}