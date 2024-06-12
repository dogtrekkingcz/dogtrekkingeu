namespace PetsOnTrail.Interfaces.Actions.Entities.Entries;

public sealed record CreateEntryResponse
{
    public Guid Id { get; init; } = Guid.Empty;
}