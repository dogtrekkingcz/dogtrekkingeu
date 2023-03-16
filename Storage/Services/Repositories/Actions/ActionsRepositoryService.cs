using DogtrekkingCz.Storage.Models;
using MapsterMapper;
using MongoDB.Bson;
using DogtrekkingCz.Shared.Entities;
using Storage.Entities.Actions;
using Storage.Interfaces;
using Storage.Interfaces.Services;

namespace Storage.Services.Repositories
{
    internal class ActionsRepositoryService : IActionsRepositoryService
    {
        private readonly IMapper _mapper;
        private readonly IStorageService<ActionRecord> _actionsStorageService;

        public ActionsRepositoryService(IMapper mapper, IStorageService<ActionRecord> actionsStorageService)
        {
            _mapper = mapper;
            _actionsStorageService = actionsStorageService;
        }

        public async Task<AddActionResponse> AddActionAsync(AddActionRequest request)
        {
            var addRequest = _mapper.Map<ActionRecord>(request);

            if (addRequest.Id == null)
            {
                addRequest.Id = Guid.NewGuid().ToString();
            }
            
            var addedActionRecord = await _actionsStorageService.AddAsync(addRequest);

            var response = new AddActionResponse
            {
                Id = addedActionRecord?.Id ?? ""
            };

            return response;
        }

        public async Task<UpdateActionResponse> UpdateActionAsync(UpdateActionRequest request)
        {
            var updateRequest = _mapper.Map<ActionRecord>(request);
            
            var result = await _actionsStorageService.UpdateAsync(updateRequest);

            return new UpdateActionResponse
            {
                Id = result.Id
            };
        }

        public async Task DeleteActionAsync(DeleteActionRequest request)
        {
            var deleteRequest = _mapper.Map<ActionRecord>(request);

            await _actionsStorageService.DeleteAsync(deleteRequest);
        }

        public async Task<GetActionResponse> GetActionAsync(GetActionRequest request)
        {
            var getRequest = _mapper.Map<ActionRecord>(request);

            var result = await _actionsStorageService.GetAsync(getRequest);

            var response = _mapper.Map<GetActionResponse>(result);

            return response;
        }

        public async Task<GetAllActionsResponse> GetAllActionsAsync()
        {
            var getAllActions = await _actionsStorageService.GetAllAsync();

            var actions = new List<ActionDto>();
            foreach (var action in getAllActions
                .Where(a => a.Id != null))
            {
                actions.Add(_mapper.Map<ActionDto>(action));
            }

            var response = new GetAllActionsResponse
            {
                Actions = actions
            };
            
            return response;
        }

        public async Task<GetAllActionsWithDetailsResponse> GetAllActionsDetailsAsync()
        {
            var getAllActions = await _actionsStorageService.GetAllAsync();

            var actions = new List<ActionDto>();
            foreach (var action in getAllActions)
            {
                actions.Add(_mapper.Map<ActionDto>(action));
            }

            var response = new GetAllActionsWithDetailsResponse
            {
                Actions = actions
            };
            
            return response;
        }
    }
}
