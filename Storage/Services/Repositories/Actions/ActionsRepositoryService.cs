using MapsterMapper;
using Microsoft.Extensions.Logging;
using Storage.Entities.Actions;
using Storage.Extensions;
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
            _logger.LogInformation($"{nameof(AddActionAsync)} - request: '{request?.Dump()}'");

            var addRequest = _mapper.Map<ActionRecord>(request);
            _logger.LogInformation($"{nameof(AddActionAsync)} - addRequest: '{addRequest?.Dump()}'");
            
            var addedActionRecord = await _actionsStorageService.AddOrUpdateAsync(addRequest, cancellationToken);

            var response = new CreateActionInternalStorageResponse
            {
                Id = addedActionRecord?.Id ?? ""
            };

            return response;
        }

        public async Task<UpdateActionInternalStorageResponse> UpdateActionAsync(UpdateActionInternalStorageRequest request, CancellationToken cancellationToken)
        {
            Console.WriteLine($"{nameof(UpdateActionAsync)} - request: '{request?.Dump()}'");
            var updateRequest = _mapper.Map<ActionRecord>(request);
            
            var result = await _actionsStorageService.AddOrUpdateAsync(updateRequest, cancellationToken);

            return new UpdateActionInternalStorageResponse
            {
                Id = result.Id
            };
        }

        public async Task DeleteActionAsync(Guid id, CancellationToken cancellationToken)
        {
            Console.WriteLine($"{nameof(DeleteActionAsync)} - id: '{id}'");
            await _actionsStorageService.DeleteAsync(id.ToString(), cancellationToken);
        }

        public async Task<GetActionInternalStorageResponse> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            var result = await _actionsStorageService.GetAsync(id.ToString(), cancellationToken);
            Console.WriteLine($"{nameof(GetAsync)} - response from storage: '{result?.Dump()}'");
            
            var response = _mapper.Map<GetActionInternalStorageResponse>(result);
            if (response == null)
                Console.WriteLine($"{nameof(GetAsync)} - action with id: '{id}' not found");
            else
                Console.WriteLine($"{nameof(GetAsync)}: '{response.Dump()}'");

            return response;
        }

        public async Task<GetAllActionsInternalStorageResponse> GetAllActionsAsync(CancellationToken cancellationToken)
        {
            var getAllActions = await _actionsStorageService.GetAllAsync(cancellationToken);

            _logger.LogInformation($"{nameof(GetAllActionsAsync)} - response from storage: '{getAllActions?.Dump()}'");

            var actions = new List<GetAllActionsInternalStorageResponse.ActionDto>();
            foreach (var action in getAllActions
                .Where(a => a.Id != null))
            {
                actions.Add(_mapper.Map<GetAllActionsInternalStorageResponse.ActionDto>(action));
            }

            var response = new GetAllActionsInternalStorageResponse
            {
                Actions = actions
            };

            _logger.LogInformation($"{nameof(GetAllActionsAsync)} - response: '{response?.Dump()}'");
            
            return response;
        }

        public async Task<AddResultInternalStorageResponse> AddResultAsync(AddResultInternalStorageRequest request, CancellationToken cancellationToken)
        {
            Console.WriteLine($"{nameof(AddResultAsync)} - request: '{request?.Dump()}'");
            var action = await _actionsStorageService.GetAsync(request.ActionId.ToString(), cancellationToken);

            var race = action.Races.First(race => race.Id == request.RaceId);

            var category = race.Categories.First(category => category.Id == request.CategoryId);
            
            category.Racers.Add(_mapper.Map<ActionRecord.RacerDto>(request) with
            {
                PassedCheckpoints = new List<ActionRecord.PassedCheckpointDto>()
            });

            await _actionsStorageService.AddOrUpdateAsync(action, cancellationToken);

            return new AddResultInternalStorageResponse();
        }

        public async Task<GetSelectedActionsInternalStorageResponse> GetSelectedActionsAsync(GetSelectedActionsInternalStorageRequest request, CancellationToken cancellationToken)
        {
            Console.WriteLine($"{nameof(GetSelectedActionsAsync)} - request: '{request?.Dump()}'");
            
            var selectedActions = await _actionsStorageService.GetSelectedListAsync(request.Ids, cancellationToken);

            var actions = new List<GetSelectedActionsInternalStorageResponse.ActionDto>();
            foreach (var action in selectedActions)
            {
                actions.Add(_mapper.Map<GetSelectedActionsInternalStorageResponse.ActionDto>(action));
            }

            var response = new GetSelectedActionsInternalStorageResponse
            {
                Actions = actions
            };
            
            Console.WriteLine($"{nameof(GetSelectedActionsAsync)} - response: '{response?.Dump()}'");
            
            return response;
        }
    }
}
