namespace PetsOnTrail.Interfaces.Actions.Entities.Actions;

public sealed record GetActionRequest
{
    public Guid Id { get; set; }
}