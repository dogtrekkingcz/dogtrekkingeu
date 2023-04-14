using DogtrekkingCzShared.Entities;

namespace DogtrekkingCz.Entries.Interface.Entities;

public sealed record GetAllEntriesResponse
{
    public IList<EntryDto> Entries { get; init; }
}