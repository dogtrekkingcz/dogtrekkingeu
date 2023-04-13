using DogtrekkingCzShared.Entities;

namespace DogtrekkingCz.Entries.Interface.Entities;

public sealed record GetEntriesByActionResponse
{
    public IList<EntryDto> Entries { get; init; }
}