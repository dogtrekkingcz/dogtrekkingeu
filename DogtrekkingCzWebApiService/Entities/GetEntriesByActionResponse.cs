using DogtrekkingCzShared.Entities;

namespace DogtrekkingCzWebApiService.Entities;

public sealed record GetEntriesByActionResponse
{
    public IList<EntryDto> Entries { get; init; }
}