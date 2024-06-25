using MapsterMapper;
using Microsoft.Extensions.Logging;
using Storage.Entities.Actions;
using Storage.Extensions;
using Storage.Interfaces;
using Storage.Models;

namespace Storage.Services.Repositories.Actions;

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
        var addRequest = _mapper.Map<ActionRecord>(request);
        
        var addedActionRecord = await _actionsStorageService.AddOrUpdateAsync(addRequest, cancellationToken);

        var response = new CreateActionInternalStorageResponse
        {
            Id = addedActionRecord?.Id ?? Guid.Empty
        };

        return response;
    }

    public async Task<UpdateActionInternalStorageResponse> UpdateActionAsync(UpdateActionInternalStorageRequest request, CancellationToken cancellationToken)
    {
        var updateRequest = _mapper.Map<ActionRecord>(request);
        
        var result = await _actionsStorageService.AddOrUpdateAsync(updateRequest, cancellationToken);

        return new UpdateActionInternalStorageResponse
        {
            Id = result.Id
        };
    }

    public async Task DeleteActionAsync(Guid id, CancellationToken cancellationToken)
    {
        await _actionsStorageService.DeleteAsync(id, cancellationToken);
    }

    public async Task<GetActionInternalStorageResponse> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        var result = await _actionsStorageService.GetAsync(id, cancellationToken);
        
        var response = _mapper.Map<GetActionInternalStorageResponse>(result);
        if (response == null)
            Console.WriteLine($"{nameof(GetAsync)} - action with id: '{id}' not found");

        return response;
    }

    public async Task<GetAllActionsInternalStorageResponse> GetAllActionsAsync(CancellationToken cancellationToken)
    {
        var getAllActions = await _actionsStorageService.GetAllAsync(cancellationToken);

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
        
        return response;
    }

    public async Task<AddResultInternalStorageResponse> AddResultAsync(AddResultInternalStorageRequest request, CancellationToken cancellationToken)
    {
        Console.WriteLine($"{nameof(AddResultAsync)} - request: '{request?.Dump()}'");
        var action = await _actionsStorageService.GetAsync(request.ActionId, cancellationToken);

        var race = action.Races.First(race => race.Id == request.RaceId);

        var category = race.Categories.First(category => category.Id == request.CategoryId);
        
        category.Racers.Add(_mapper.Map<ActionRecord.RacerDto>(request) with
        {
            PassedCheckpoints = new List<ActionRecord.PassedCheckpointDto>(),
            Pets = request.Pets.Select(petName => new ActionRecord.PetDto { Id = Guid.NewGuid(), Name = petName }).ToList()
        });

        await _actionsStorageService.AddOrUpdateAsync(action, cancellationToken);

        return new AddResultInternalStorageResponse();
    }

    public async Task<GetSelectedActionsInternalStorageResponse> GetSelectedActionsAsync(GetSelectedActionsInternalStorageRequest request, CancellationToken cancellationToken)
    {
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
        
        return response;
    }

    public async Task<GetSimpleActionsListByTypeInternalStorageResponse> GetSimpleActionsListByTypeAsync(IList<Guid> typeIds, CancellationToken cancellationToken)
    {
        var actions = await _actionsStorageService.GetSelectedListAsync("TypeId", typeIds.Select(id => id).ToList(), cancellationToken);

        var response = new GetSimpleActionsListByTypeInternalStorageResponse
        {
            Actions = actions.Select(action => _mapper.Map<GetSimpleActionsListByTypeInternalStorageResponse.ActionDto>(action)).ToList()
        };

        return response;
    }
}
