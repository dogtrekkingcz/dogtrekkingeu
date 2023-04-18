using DogtrekkingCzShared.Entities;

namespace DogtrekkingCz.Interfaces.Actions.Entities.Entries;

public sealed record GetEntriesByActionResponse
{
    public IList<EntryDto> Entries { get; init; }
}