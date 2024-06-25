namespace PetsOnTrailApp.Models;

public sealed record RaceModel : BaseSynchronizedModel
{
    public Guid ActionId { get; init; } = default(Guid);
    public Guid RaceId { get; init; } = default(Guid);

    public RaceDto Data { get; init; } = new();

    public sealed record RaceDto
    {
        public Guid Id { get; init; } = default(Guid);
        public string Name { get; init; } = string.Empty;

        public double? Distance { get; init; } = 0.0;

        public double? Incline { get; init; } = 0.0;

        public DateTimeOffset EnteringFrom = DateTimeOffset.Now;

        public DateTimeOffset EnteringTo = DateTimeOffset.Now.AddYears(1);

        public int MaxNumberOfCompetitors = Int32.MaxValue;

        public DateTimeOffset Begin = DateTimeOffset.Now;

        public DateTimeOffset End = DateTimeOffset.Now.AddDays(10);

        public IList<CategoryDto> Categories { get; init; } = new List<CategoryDto>();

        public List<CheckpointDto> Checkpoints { get; init; } = new List<CheckpointDto>();
    }

    public sealed record CheckpointDto
    {
        public Guid Id { get; init; } = default(Guid);
        public string Name { get; init; } = string.Empty;
        public LatLngDto Position { get; init; } = new();
    }

    public sealed record LatLngDto
    {
        public double Latitude { get; init; } = 0.0;

        public double Longitude { get; init; } = 0.0;
    }

    public sealed record CategoryDto
    {
        public Guid Id { get; init; } = default(Guid);

        public string Name { get; init; } = string.Empty;

        public string Description { get; init; } = string.Empty;
    }

    public enum RaceState
    {
        NotValid = 0,
        NotStarted,
        Started,
        Finished,
        DidNotFinished,
        Disqualified
    }
}
