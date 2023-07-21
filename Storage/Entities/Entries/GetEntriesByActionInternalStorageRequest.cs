namespace Storage.Entities.Entries;

public sealed record GetEntriesByActionInternalStorageRequest
{
    public Guid ActionId { get; set; }

    public bool IncludeAlreadyAccepted { get; set; } = false;
}