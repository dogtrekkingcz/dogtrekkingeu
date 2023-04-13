using DogtrekkingCz.Storage.Entities.Entries;
using Storage.Interfaces;

namespace Storage.Services.Repositories.Entries;

internal sealed class EntriesRepositoryService : IEntriesRepositoryService
{
    public async Task<CreateEntryStorageResponse> CreateEntryAsync(CreateEntryStorageRequest request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(new CreateEntryStorageResponse { Id = Guid.NewGuid() });
    }
}