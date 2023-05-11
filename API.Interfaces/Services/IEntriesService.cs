using DogsOnTrail.Interfaces.Actions.Entities.Entries;

namespace DogsOnTrail.Interfaces.Actions.Services;

public interface IEntriesService
{
    Task<CreateEntryResponse> CreateEntryAsync(CreateEntryRequest request, CancellationToken cancellationToken);

    Task<GetEntriesByActionResponse> GetEntriesByActionAsync(GetEntriesByActionRequest request, CancellationToken cancellationToken);
    
    Task<GetAllEntriesResponse> GetAllEntriesAsync(GetAllEntriesRequest request, CancellationToken cancellationToken);

    Task DeleteEntryAsync(DeleteEntryRequest request, CancellationToken cancellationToken);
}