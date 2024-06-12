namespace Storage.Models;

internal sealed record CheckpointRecord : BaseRecord, IRecord
{
    public Guid ActionId { get; set; } = Guid.Empty;

    public Guid CheckpointId { get; set; } = Guid.Empty;

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
    
    public DateTimeOffset CheckpointTime { get; set; }
    
    public DateTimeOffset ServerTime { get; set; }
    
    public DateTimeOffset Created { get; set; }

    public string Data { get; set; } = string.Empty;
    
    public LatLngDto Position { get; set; }

    public string Note { get; set; } = string.Empty;
    
    public sealed record LatLngDto
    {
        public double Latitude { get; set; } = Double.NaN;

        public double Longitude { get; set; } = Double.NaN;
    }
}