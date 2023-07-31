namespace Storage.Entities.Checkpoints;

public sealed record GetCheckpointItemsInternalStorageResponse
{
    public IEnumerable<CheckpointItemDto> Items { get; set; } = new List<CheckpointItemDto>();

    public sealed record CheckpointItemDto
    {
        public Guid Id { get; set; }
        
        public Guid UserId { get; set; }
        
        public Guid ActionId { get; set; }

        public Guid CheckpointId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTimeOffset CheckpointTime { get; set; }

        public DateTimeOffset ServerTime { get; set; }

        public DateTimeOffset Created { get; set; }

        public string Data { get; set; }
        
        public LatLngDto Position { get; set; } = new LatLngDto();
    }
    
    public sealed record LatLngDto
    {
        public double Latitude { get; set; } = Double.NaN;

        public double Longitude { get; set; } = Double.NaN;
    }
}