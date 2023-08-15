namespace GpsTracker.Services;

public interface IGpsPositionService
{
    Task<PositionDto> GetCachedLocationAsync();

    Task<PositionDto> GetCurrentLocationAsync();
    
    PositionDto CurrentPosition { get; set; }
    
    public event Action OnChange;
    
    public sealed record PositionDto
    {
        public double Latitude { get; set; } = double.NaN;

        public double Longitude { get; set; } = double.NaN;

        public double Altitude { get; set; } = double.NaN;

        public double Accuracy { get; set; } = double.NaN;
        
        public DateTimeOffset Time { get; set; } = DateTimeOffset.MinValue;
    }
}