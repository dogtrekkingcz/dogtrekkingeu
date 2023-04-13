using DogtrekkingCz.Entries.Interface.Entities;
using DogtrekkingCz.Entries.Interface.Services;
using DogtrekkingCz.Storage.Entities.Entries;
using Storage.Interfaces;

namespace DogtrekkingCz.Entries
{
    internal class EntriesService : IEntriesService
    {
        private readonly IEntriesRepositoryService _entriesRepositoryService;

        public EntriesService(IEntriesRepositoryService entriesRepositoryService)
        {
            _entriesRepositoryService = entriesRepositoryService;
        }

        public async Task<CreateEntryResponse> CreateEntryAsync(CreateEntryRequest request, CancellationToken cancellationToken)
        {
            var response = await _entriesRepositoryService.CreateEntryAsync(new CreateEntryStorageRequest
            {

            }, cancellationToken);

            return new CreateEntryResponse
            {
                Id = response.Id
            };
        }
    }
}
