using DogtrekkingCz.Entries.Interface.Entities;

namespace DogtrekkingCz.Entries.Interface.Services;

public interface IEntriesService
{
    Task<CreateEntryResponse> CreateEntryAsync(CreateEntryRequest request, CancellationToken cancellationToken);

    Task<GetEntriesByActionResponse> GetEntriesByAction(GetEntriesByActionRequest request, CancellationToken cancellationToken);
}