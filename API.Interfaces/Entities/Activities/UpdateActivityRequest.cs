namespace PetsOnTrail.Interfaces.Actions.Entities.Activities;

public sealed record UpdateActivityRequest
{
    public Guid? Id { get; set; } = null;

    public IEnumerable<PositionDto> Positions { get; set; } = new List<PositionDto>(0);

    public sealed record PositionDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        
        public DateTimeOffset Time { get; set; } = DateTimeOffset.Now;
            
        public double Latitude { get; set; } = double.NaN;

        public double Longitude { get; set; } = double.NaN;

        public double Altitude { get; set; } = double.NaN;

        public double Accuracy { get; set; } = double.NaN;

        public double Course { get; set; } = double.NaN;

        public string Note { get; set; } = string.Empty;
        
        public List<string> PhotoUris { get; set; } = new();
    }
}