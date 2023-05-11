using SharedCode.Entities;

namespace Storage.Entities.Entries;

public sealed record GetEntriesByActionInternalStorageResponse
{
    public IList<EntryDto> Entries { get; init; }
}