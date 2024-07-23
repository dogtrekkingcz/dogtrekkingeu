namespace PetsOnTrail.Interfaces.Actions.Entities.Actions;

public sealed record GetActionsRequest
{
    public IEnumerable<Guid> TypeIds { get; init; } = Array.Empty<Guid>();
}