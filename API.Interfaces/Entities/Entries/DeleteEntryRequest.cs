namespace PetsOnTrail.Interfaces.Actions.Entities.Entries;

public sealed record DeleteEntryRequest
{
    public Guid Id { get; set; } = Guid.Empty;
}