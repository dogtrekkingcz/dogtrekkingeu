using Protos.Activities.GetActivities;

namespace PetsOnTrailApp.Models;

public sealed record ActivityModel : BaseSynchronizedModel
{
    public Guid Id { get; init; }
    public Guid ActionId { get; init; } = Guid.Empty;
    public Guid RaceId { get; init; } = Guid.Empty;
    public Guid CategoryId { get; init; } = Guid.Empty;
    public Guid TypeId { get; init; } = Guid.Empty;
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public DateTimeOffset? Start { get; init; } = null;
    public DateTimeOffset? End { get; init; } = null;
    public bool IsPublic { get; init; }
    public IList<PositionDto> Positions { get; init; } = new List<PositionDto>(0);
    public IList<PetDto> Pets { get; init; } = new List<PetDto>(0);

    public sealed record PositionDto
    {
        public Guid Id { get; init; } = Guid.Empty;
        public DateTimeOffset? Time { get; init; } = null;
        public double Latitude { get; init; }
        public double Longitude { get; init; }
        public double Altitude { get; init; }
        public double Accuracy { get; init; }
        public double Course { get; init; }
        public string Note { get; init; }
        public IList<string> PhotoUris { get; init; } = new List<string>(0);
    }
    
    public sealed record PetDto
    {
        public Guid Id { get;init; } = Guid.Empty;
        public string Chip { get; init; }
        public string Name { get; init; }
        public string Breed { get; init; }
        public string Color { get; init; }
        public string Kennel { get; init; }
        public DateTimeOffset? BirthDate { get; init; } = null;
    }
}
