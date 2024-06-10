namespace PetsOnTrail.Interfaces.Actions.Entities.Activities;

public sealed record AddPointsRequest
{
    public Guid ActivityId { get; init; } = Guid.Empty;

    public List<PointDto> Points { get; init; } = new(0);

    public sealed record PointDto
    {
        public Guid Id { get; init; } = Guid.Empty;

        public DateTimeOffset Time { get; init; } = DateTimeOffset.Now;

        public double Latitude { get; init; } = double.NaN;

        public double Longitude { get; init; } = double.NaN;

        public double Altitude { get; init; } = double.NaN;

        public double Accuracy { get; init; } = double.NaN;

        public double Course { get; init; } = double.NaN;

        public string Note { get; init; } = string.Empty;

        public string PhotoUris { get; init; } = string.Empty;
    }
}