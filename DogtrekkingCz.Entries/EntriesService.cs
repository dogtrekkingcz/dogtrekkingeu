using DogtrekkingCz.Entries.Interface.Entities;
using DogtrekkingCz.Entries.Interface.Services;
using MapsterMapper;
using Storage.Entities.Entries;
using Storage.Interfaces;

namespace DogtrekkingCz.Entries
{
    internal class EntriesService : IEntriesService
    {
        private readonly IMapper _mapper;
        private readonly IEntriesRepositoryService _entriesRepositoryService;

        public EntriesService(IMapper mapper, IEntriesRepositoryService entriesRepositoryService)
        {
            _mapper = mapper;
            _entriesRepositoryService = entriesRepositoryService;
        }

        public async Task<CreateEntryResponse> CreateEntryAsync(CreateEntryRequest request, CancellationToken cancellationToken)
        {
            var createEntryInternalStorageRequest = _mapper.Map<CreateEntryInternalStorageRequest>(request);
            var response = await _entriesRepositoryService.CreateEntryAsync(createEntryInternalStorageRequest, cancellationToken);

            return new CreateEntryResponse
            {
                Id = response.Id
            };
        }

        public async Task<GetEntriesByActionResponse> GetEntriesByAction(GetEntriesByActionRequest request, CancellationToken cancellationToken)
        {
            var getEntriesByActionInternalStorageRequest = _mapper.Map<GetEntriesByActionInternalStorageRequest>(request);

            var result = await _entriesRepositoryService.GetEntriesByActionAsync(getEntriesByActionInternalStorageRequest, cancellationToken);

            var response = _mapper.Map<GetEntriesByActionResponse>(result);

            return response;
        }
    }
}
