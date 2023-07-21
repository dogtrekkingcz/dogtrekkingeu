using Storage.Entities.Entries;

namespace Storage.Interfaces;

public interface IEntriesRepositoryService
{
    Task<CreateEntryInternalStorageResponse> CreateEntryAsync(CreateEntryInternalStorageRequest request, CancellationToken cancellationToken);

    Task<GetEntriesByActionInternalStorageResponse> GetEntriesByActionAsync(GetEntriesByActionInternalStorageRequest request, CancellationToken cancellationToken);
    
    Task<GetAllEntriesInternalStorageResponse> GetAllEntriesAsync(GetAllEntriesInternalStorageRequest request, CancellationToken cancellationToken);

    Task<GetEntryInternalStorageResponse> GetAsync(Guid registrationId, CancellationToken cancellationToken);

    Task UpdateEntryAsync(UpdateEntryInternalStorageRequest request, CancellationToken cancellationToken);
    
    Task DeleteEntryAsync(DeleteEntryInternalStorageRequest request, CancellationToken cancellationToken);
}