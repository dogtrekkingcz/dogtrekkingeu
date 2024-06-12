namespace Storage.Entities.Entries;

public sealed record CreateEntryInternalStorageResponse
{
    public Guid Id { get; init; } = Guid.Empty;
}