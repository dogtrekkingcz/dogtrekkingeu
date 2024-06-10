namespace Storage.Entities.Activities;

public sealed record UpdateActivityInternalStorageRequest
{
    public Guid Id { get; init; }

    public Guid UserId { get; init; } = Guid.Empty;

    public Guid ActionId { get; init; } = Guid.Empty;

    public Guid RaceId { get; init; } = Guid.Empty;

    public Guid CategoryId { get; init; } = Guid.Empty;

    public Guid TypeId { get; init; } = Guid.Empty;

    public string Name { get; init; } = string.Empty;

    public string Description { get; init; } = string.Empty;

    public DateTimeOffset Start { get; init; } = DateTimeOffset.Now;

    public DateTimeOffset? End { get; init; } = null;

    public bool IsPublic { get; init; } = true;

    public List<PetDto> Pets { get; init; } = new List<PetDto>(0);

    public List<PositionDto> Positions { get; init; } = new List<PositionDto>(0);

    public sealed record PositionDto
    {
        public Guid Id { get; init; } = Guid.NewGuid();

        public DateTimeOffset Time { get; init; } = DateTimeOffset.Now;

        public double Latitude { get; init; } = double.NaN;

        public double Longitude { get; init; } = double.NaN;

        public double Altitude { get; init; } = double.NaN;

        public double Accuracy { get; init; } = double.NaN;

        public double Course { get; init; } = double.NaN;

        public string Note { get; init; } = string.Empty;

        public List<string> PhotoUris { get; init; } = new();
    }

    public sealed record PetDto
    {
        public Guid Id { get; init; } = Guid.NewGuid();

        public string? Chip { get; init; }

        public string? Name { get; init; }

        public string? Breed { get; init; }

        public string? Color { get; init; }

        public string Kennel { get; init; }

        public DateTimeOffset? BirthDate { get; init; }
    }
}
