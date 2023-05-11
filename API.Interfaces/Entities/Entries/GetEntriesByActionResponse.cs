using SharedCode.Entities;

namespace DogsOnTrail.Interfaces.Actions.Entities.Entries;

public sealed record GetEntriesByActionResponse
{
    public IList<EntryDto> Entries { get; init; }
}