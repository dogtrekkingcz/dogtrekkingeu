namespace PetsOnTrail.Interfaces.Actions.Entities.Activities;

public sealed record AddPointResponse
{
    public Guid Id { get; init; } = Guid.Empty;
}