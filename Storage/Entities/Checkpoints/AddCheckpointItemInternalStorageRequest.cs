namespace Storage.Entities.Checkpoints;

public sealed record AddCheckpointItemInternalStorageRequest
{
    public Guid Id { get; set; } = Guid.Empty;

    public string UserId { get; set; } = string.Empty;
    
    public Guid ActionId { get; set; } = Guid.Empty;
    
    public Guid CheckpointId { get; set; } = Guid.Empty;
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public DateTimeOffset CheckpointTime { get; set; }
    
    public DateTimeOffset ServerTime { get; set; }
    
    public DateTimeOffset Created { get; set; }
    
    public string Data { get; set; }

    public LatLngDto Position { get; set; } = new LatLngDto();
    
    public string Note { get; set; }

    public sealed record LatLngDto
    {
        public double Latitude { get; set; } = Double.NaN;

        public double Longitude { get; set; } = Double.NaN;
    }
}