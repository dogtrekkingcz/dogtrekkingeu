namespace PetsOnTrail.Interfaces.Actions.Entities.Actions;

public sealed record DsqRequest
{
    public Guid ActionId { get; init; } = Guid.Empty;
    public Guid RaceId { get; init; } = Guid.Empty;
    public Guid CategoryId { get; init; } = Guid.Empty;
    public Guid RacerId { get; init; } = Guid.Empty;
}
