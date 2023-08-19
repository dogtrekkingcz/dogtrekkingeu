using Google.Type;
using GpsTracker.Services.Storage;
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
            var checkpointsClient = ServiceHelper.GetService<Protos.Checkpoints.Checkpoints.CheckpointsClient>();
            var notUploadedData = await _positionHistoryService.GetItemsNotSynchronizedAsync();
            
            foreach (var item in notUploadedData) 
            {
                await checkpointsClient.addCheckpointAsync(new AddCheckpointRequest
                {
                    Data = "",
                    Position = new LatLng
                    {
                        Latitude = item.Latitude,
                        Longitude = item.Longitude
                    },
                    ActionId = item.ActionId.ToString(),
                    Description = string.Empty,
                    Name = string.Empty,
                    Note = string.Empty,
                    CheckpointId = Guid.Empty.ToString(),
                    CheckpointTime = item.Time.ToGoogleDateTime()
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

        public Guid ActionId { get; set; } = Guid.Empty;
        
        public DateTimeOffset? TimeOfSynchronizationWithServer { get; set; } = null;
        
        public double Latitude { get; set; } = double.NaN;

        public double Longitude { get; set; } = double.NaN;

        public double Altitude { get; set; } = double.NaN;

        public double Accuracy { get; set; } = double.NaN;

        public DateTimeOffset Time { get; set; } = DateTimeOffset.MinValue;
    }
}