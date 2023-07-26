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
                addRequest.Id = Guid.NewGuid().ToString();
            }

            var addedActionRightsRecord = await _actionRightsStorageService.AddAsync(addRequest, cancellationToken);

            var response = new AddActionRightsInternalStorageResponse
            {
                Id = addedActionRightsRecord?.Id ?? ""
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

            var response = _mapper.Map<GetAllRightsInternalStorageResponse>(result);

            return response;
        }
    }
}
