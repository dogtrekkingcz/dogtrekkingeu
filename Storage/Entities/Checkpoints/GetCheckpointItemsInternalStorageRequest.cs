namespace Storage.Entities.Checkpoints;

public sealed record GetCheckpointItemsInternalStorageRequest
{
    public DateTimeOffset From { get; set; }
    
    public Guid? ActionId { get; set; }
    
    public Guid? CheckpointId { get; set; }
    
    public string? UserId { get; set; }
    
    public LatLngDto? Position { get; set; }
    
    public double? PositionDistanceInMeters { get; set; }

    public sealed record LatLngDto
    {
        public double Latitude { get; set; }
        
        public double Longitude { get; set; }
    }
}