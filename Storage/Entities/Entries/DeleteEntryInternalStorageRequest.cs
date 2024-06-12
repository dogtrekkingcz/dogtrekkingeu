namespace Storage.Entities.Entries;

public sealed record DeleteEntryInternalStorageRequest
{
    public Guid Id { get; init; } = Guid.Empty;
}