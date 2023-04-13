using Storage.Entities.Entries;

namespace Storage.Interfaces;

public interface IEntriesRepositoryService
{
    Task<CreateEntryStorageResponse> CreateEntryAsync(CreateEntryStorageRequest request, CancellationToken cancellationToken);
}