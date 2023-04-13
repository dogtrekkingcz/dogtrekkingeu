namespace Storage.Entities.Entries;

public sealed record GetEntriesByActionInternalStorageRequest
{
    public string ActionId { get; set; }
}