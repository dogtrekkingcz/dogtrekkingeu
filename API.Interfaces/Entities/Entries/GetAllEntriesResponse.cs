using SharedCode.Entities;

namespace DogsOnTrail.Interfaces.Actions.Entities.Entries;

public sealed record GetAllEntriesResponse
{
    public IList<EntryDto> Entries { get; init; }
}