using DogtrekkingCz.Storage.Models;
using MapsterMapper;
using MongoDB.Bson;
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
            var action = new ActionRecord
            {
                Name = request.Name,
                Description = request.Description,
                Owner = new ActionRecord.OwnerDto
                {
                    Id = request.Owner.Id,
                    Email = request.Owner.Email,
                    FirstName = request.Owner.FirstName,
                    FamilyName = request.Owner.FamilyName
                }
            };

            var addedActionRecord = await _actionsStorageService.AddAsync(action);

            var response = new AddActionResponse
            {
                Id = addedActionRecord?.Id ?? ""
            };

            return response;
        }

        public async Task<UpdateActionResponse> UpdateActionAsync(UpdateActionRequest request)
        {
            Console.WriteLine(request.ToJson());
            
            var updateRequest = _mapper.Map<ActionRecord>(request);
            
            Console.WriteLine(updateRequest.ToJson());
            
            var result = await _actionsStorageService.UpdateAsync(updateRequest);

            return new UpdateActionResponse
            {
                Id = result.Id
            };
        }

        public async Task<GetAllActionsResponse> GetAllActionsAsync()
        {
            var getAllActions = await _actionsStorageService.GetAllAsync();

            var response = new GetAllActionsResponse
            {
                Actions = _mapper.Map<IReadOnlyList<GetAllActionsResponse.ActionDto>>(getAllActions)
            };
            
            return response;
        }
    }
}
