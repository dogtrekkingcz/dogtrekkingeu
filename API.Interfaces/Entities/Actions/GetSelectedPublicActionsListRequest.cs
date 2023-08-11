namespace DogsOnTrail.Interfaces.Actions.Entities.Actions;

public sealed record GetSelectedPublicActionsListRequest
{
    public List<Guid> Ids { get; set; } = new();
}