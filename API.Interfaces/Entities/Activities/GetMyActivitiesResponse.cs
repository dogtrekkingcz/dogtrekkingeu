namespace DogsOnTrail.Interfaces.Actions.Entities.Activities;

public sealed record GetMyActivitiesResponse
{
    public List<ActivityDto> Activities { get; set; } = new();

    public sealed record ActivityDto
    {
        public Guid Id { get; } = Guid.Empty;

        public Guid ActionId { get; } = Guid.Empty;

        public Guid RaceId { get; } = Guid.Empty;

        public Guid CategoryId { get; } = Guid.Empty;

        public string Name { get; set; } = string.Empty;

        public string Description { get; } = string.Empty;
        
        public DateTimeOffset Start { get; set; } = DateTimeOffset.MinValue;
        
        public DateTimeOffset? End { get; set; } = null;
        
        public bool IsPublic { get; set; } = true;
    }
}