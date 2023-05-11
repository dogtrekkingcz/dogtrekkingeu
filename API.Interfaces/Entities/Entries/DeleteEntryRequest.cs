namespace DogsOnTrail.Interfaces.Actions.Entities.Entries;

public sealed record DeleteEntryRequest
{
    public string Id { get; set; }
}