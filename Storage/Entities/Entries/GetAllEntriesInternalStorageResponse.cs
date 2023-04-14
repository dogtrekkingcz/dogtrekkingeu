using DogtrekkingCzShared.Entities;

namespace Storage.Entities.Entries;

public sealed record GetAllEntriesInternalStorageResponse
{
    public IList<EntryDto> Entries { get; init; }
}