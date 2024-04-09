namespace PetsOnTrail.Interfaces.Actions.Entities.Activities;

public sealed record GetMyActivitiesResponse
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
        
        public List<Guid> PetIds { get; set; } = new();
        
        public bool IsPublic { get; set; } = true;
    }
}