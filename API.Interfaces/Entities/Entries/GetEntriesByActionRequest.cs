namespace DogsOnTrail.Interfaces.Actions.Entities.Entries;

public sealed record GetEntriesByActionRequest
{
    public string ActionId { get; set; }

    public bool IncludeAlreadyAccepted { get; set; } = false;
}