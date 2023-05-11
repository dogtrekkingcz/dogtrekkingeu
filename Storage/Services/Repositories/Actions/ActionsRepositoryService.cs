using SharedCode.Entities;
using MapsterMapper;
using Microsoft.Extensions.Logging;
using Storage.Entities.Actions;
using Storage.Interfaces;
using Storage.Models;

namespace Storage.Services.Repositories.Actions
{
    internal class ActionsRepositoryService : IActionsRepositoryService
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IStorageService<ActionRecord> _actionsStorageService;

        public ActionsRepositoryService(ILogger<ActionsRepositoryService> logger, IMapper mapper, IStorageService<ActionRecord> actionsStorageService)
        {
            _logger = logger;
            _mapper = mapper;
            _actionsStorageService = actionsStorageService;
        }

        public async Task<CreateActionInternalStorageResponse> AddActionAsync(CreateActionInternalStorageRequest request, CancellationToken cancellationToken)
        {
            _logger.LogDebug("\'{AddActionAsyncName}\': {Request}", nameof(AddActionAsync), request);
            var addRequest = _mapper.Map<ActionRecord>(request);
            
            var addedActionRecord = await _actionsStorageService.AddAsync(addRequest, cancellationToken);

            var response = new CreateActionInternalStorageResponse
            {
                Id = addedActionRecord?.Id ?? ""
            };

            return response;
        }

        public async Task<UpdateActionInternalStorageResponse> UpdateActionAsync(UpdateActionInternalStorageRequest request, CancellationToken cancellationToken)
        {
            var updateRequest = _mapper.Map<ActionRecord>(request);
            
            var result = await _actionsStorageService.UpdateAsync(updateRequest, cancellationToken);

            return new UpdateActionInternalStorageResponse
            {
                Id = result.Id
            };
        }

        public async Task DeleteActionAsync(DeleteActionInternalStorageRequest request, CancellationToken cancellationToken)
        {
            var deleteRequest = _mapper.Map<ActionRecord>(request);

            await _actionsStorageService.DeleteAsync(deleteRequest, cancellationToken);
        }

        public async Task<GetActionInternalStorageResponse> GetActionAsync(GetActionInternalStorageRequest request, CancellationToken cancellationToken)
        {
            var getRequest = _mapper.Map<ActionRecord>(request);

            var result = await _actionsStorageService.GetAsync(getRequest, cancellationToken);

            var response = _mapper.Map<GetActionInternalStorageResponse>(result);

            return response;
        }

        public async Task<GetAllActionsInternalStorageResponse> GetAllActionsAsync(CancellationToken cancellationToken)
        {
            var getAllActions = await _actionsStorageService.GetAllAsync(cancellationToken);

            var actions = new List<ActionDto>();
            foreach (var action in getAllActions
                .Where(a => a.Id != null))
            {
                actions.Add(_mapper.Map<ActionDto>(action));
            }

            var response = new GetAllActionsInternalStorageResponse
            {
                Actions = actions
            };
            
            return response;
        }

        public async Task<GetAllActionsWithDetailsInternalStorageResponse> GetAllActionsDetailsAsync(CancellationToken cancellationToken)
        {
            var getAllActions = await _actionsStorageService.GetAllAsync(cancellationToken);

            var actions = new List<ActionDto>();
            foreach (var action in getAllActions)
            {
                actions.Add(_mapper.Map<ActionDto>(action));
            }

            var response = new GetAllActionsWithDetailsInternalStorageResponse
            {
                Actions = actions
            };
            
            return response;
        }

        public async Task<AddResultInternalStorageResponse> AddResultAsync(AddResultInternalStorageRequest request, CancellationToken cancellationToken)
        {
            var action = await _actionsStorageService.GetAsync(new ActionRecord { Id = request.ActionId.ToString() }, cancellationToken);

            var race = action.Races.First(race => race.Id == request.RaceId);

            var category = race.Categories.First(category => category.Id == request.CategoryId);
            
            category.Racers.Add(_mapper.Map<RacerDto>(request));

            await _actionsStorageService.UpdateAsync(action, cancellationToken);

            return new AddResultInternalStorageResponse();
        }
    }
}
