using MapsterMapper;
using Storage.Entities.ActionRights;
using Storage.Interfaces;
using Storage.Models;

namespace Storage.Services.Repositories.ActionRights
{
    internal class ActionRightsRepositoryService : IActionRightsRepositoryService
    {
        private readonly IMapper _mapper;
        private readonly IStorageService<ActionRightsRecord> _actionRightsStorageService;

        public ActionRightsRepositoryService(IMapper mapper, IStorageService<ActionRightsRecord> actionRigtsStorageService)
        {
            _mapper = mapper;
            _actionRightsStorageService = actionRigtsStorageService;
        }

        public async Task<AddActionRightsInternalStorageResponse> AddActionRightsAsync(AddActionRightsInternalStorageRequest request, CancellationToken cancellationToken)
        {
            var addRequest = _mapper.Map<ActionRightsRecord>(request);

            if (addRequest.Id == null)
            {
                addRequest.Id = Guid.NewGuid();
            }

            var addedActionRightsRecord = await _actionRightsStorageService.AddOrUpdateAsync(addRequest, cancellationToken);

            var response = new AddActionRightsInternalStorageResponse
            {
                Id = addedActionRightsRecord?.Id ?? Guid.Empty
            };

            return response;
        }

        public Task DeleteActionRightsAsync(DeleteActionRightsRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<GetAllRightsInternalStorageResponse> GetAllRightsAsync(GetAllRightsInternalStorageRequest request, CancellationToken cancellationToken)
        {
            var filter = new List<(string key, Type typeOfValue, object value)> { ("UserId", typeof(string), request.UserId) };
            var result = await _actionRightsStorageService.GetByFilterAsync(filter, cancellationToken);

            if (result == null)
                return null;

            var response = new GetAllRightsInternalStorageResponse
            {
                Rights = result
                    .Select(r => _mapper.Map<GetAllRightsInternalStorageResponse.ActionRightsDto>(r))
                    .ToList()
            };

            return response;
        }
    }
}
