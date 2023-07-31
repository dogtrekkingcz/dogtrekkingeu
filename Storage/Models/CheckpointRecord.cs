namespace Storage.Models;

internal sealed record CheckpointRecord : IRecord
{
    public string? Id { get; set; } = Guid.Empty.ToString();

    public string UserId { get; set; } = string.Empty;

    public string ActionId { get; set; } = Guid.Empty.ToString();

    public string CheckpointId { get; set; } = Guid.Empty.ToString();
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public DateTimeOffset CheckpointTime { get; set; }
    
    public DateTimeOffset ServerTime { get; set; }
    
    public DateTimeOffset Created { get; set; }

    public string Data { get; set; }
    
    public LatLngDto Position { get; set; }
    
    public sealed record LatLngDto
    {
        public double Latitude { get; set; } = Double.NaN;

        public double Longitude { get; set; } = Double.NaN;
    }
}