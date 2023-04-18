using DogtrekkingCzShared.Entities;

namespace DogtrekkingCz.Interfaces.Actions.Entities.Entries;

public sealed record GetAllEntriesResponse
{
    public IList<EntryDto> Entries { get; init; }
}