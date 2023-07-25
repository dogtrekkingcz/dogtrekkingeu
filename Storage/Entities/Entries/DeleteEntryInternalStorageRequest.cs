namespace Storage.Entities.Entries;

public sealed record DeleteEntryInternalStorageRequest
{
    public string Id { get; set; }
}