namespace SharedLib.Models;

public sealed record CheckpointModel
{
    public string UserId { get; set; } = string.Empty;

    public Guid ActionId { get; set; }

    public Guid CheckpointId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
    
    public DateTimeOffset CheckpointTime { get; set; } = DateTimeOffset.Now;
    
    public DateTimeOffset ServerTime { get; set; }
    
    public DateTimeOffset Created { get; set; }

    public string Data { get; set; } = string.Empty;

    public LatLngDto Position { get; set; } = new();

    public string Note { get; set; } = string.Empty;
    
    public sealed record LatLngDto
    {
        public double Latitude { get; set; } = Double.NaN;

        public double Longitude { get; set; } = Double.NaN;
    }
}