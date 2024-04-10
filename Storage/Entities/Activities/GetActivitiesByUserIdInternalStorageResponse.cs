namespace Storage.Entities.Activities;

public sealed record GetActivitiesByUserIdInternalStorageResponse
{
    public List<ActivityDto> Activities { get; set; } = new();

    public sealed record ActivityDto
    {
        public Guid Id { get; set; } = Guid.Empty;

        public Guid ActionId { get; set; } = Guid.Empty;

        public Guid RaceId { get; set; } = Guid.Empty;

        public Guid CategoryId { get; set; } = Guid.Empty;

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
        
        public DateTimeOffset Start { get; set; } = DateTimeOffset.MinValue;
        
        public DateTimeOffset? End { get; set; } = null;

        public List<PetDto> PetIds { get; set; } = new List<PetDto>(0);

        public List<PositionDto> Positions { get; set; } = new List<PositionDto>(0);

        public bool IsPublic { get; set; } = true;
    }

    public sealed record PositionDto
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

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