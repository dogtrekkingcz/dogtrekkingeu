namespace Storage.Entities.Activities;

public sealed record UpdateActivityInternalStorageRequest
{
    public Guid Id { get; init; }

    public string UserId { get; set; } = string.Empty;

    public string ActionId { get; set; } = Guid.Empty.ToString();

    public string RaceId { get; set; } = Guid.Empty.ToString();

    public string CategoryId { get; set; } = Guid.Empty.ToString();

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public DateTimeOffset Start { get; set; } = DateTimeOffset.Now;

    public DateTimeOffset? End { get; set; } = null;

    public bool IsPublic { get; set; } = true;

    public IEnumerable<PetDto> Pets { get; set; } = new List<PetDto>(0);

    public IEnumerable<PositionDto> Positions { get; init; } = new List<PositionDto>(0);

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
