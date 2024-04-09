namespace PetsOnTrail.Interfaces.Actions.Entities.Actions;

public sealed record GetSelectedActionsRequest
{
    public required List<Guid> Ids { get; set; }
}