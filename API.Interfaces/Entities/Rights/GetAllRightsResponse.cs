namespace PetsOnTrail.Interfaces.Actions.Entities.Rights;
public sealed record GetAllRightsResponse
{
    public IReadOnlyList<ActionRightsDto> Rights { get; init; }
    
    public sealed record ActionRightsDto
    {
        public string? Id { get; set; } = Guid.Empty.ToString();

        public string UserId { get; set; } = string.Empty;

        public string ActionId { get; set; } = string.Empty;
    
        public IList<string> Roles { get; set; } = new List<string>();
    }
}
