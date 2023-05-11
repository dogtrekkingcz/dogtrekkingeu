using SharedCode.Entities;

namespace DogsOnTrailWebApiService.Entities;

public sealed record GetEntriesByActionResponse
{
    public IList<EntryDto> Entries { get; init; }
}