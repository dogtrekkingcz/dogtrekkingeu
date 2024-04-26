using API.GRPCService.Extensions;
using PetsOnTrail.Interfaces.Actions.Entities.Actions;
using PetsOnTrail.Interfaces.Actions.Services;
using Google.Protobuf.Collections;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using MapsterMapper;
using Protos.Actions;
using AcceptPaymentRequest = PetsOnTrail.Interfaces.Actions.Entities.Actions.AcceptPaymentRequest;
using Action = Protos.Actions.GetAllActions.Action;

namespace API.GRPCService.Services.Actions;

internal class ActionsService : Protos.Actions.Actions.ActionsBase
{
    private readonly ILogger _logger;
    private readonly IMapper _mapper;
    private readonly IActionsService _actionsService;

    public ActionsService(ILogger<ActionsService> logger, IMapper mapper, IActionsService actionsService)
    {
        _logger = logger;
        _mapper = mapper;
        _actionsService = actionsService;
    }

    public async override Task<Protos.Actions.GetAllActions.GetAllActionsResponse> getAllActions(Protos.Actions.GetAllActions.GetAllActionsRequest request, ServerCallContext context)
    {
        var getAllActionsRequest = _mapper.Map<GetAllActionsRequest>(request);
        
        var allActions = await _actionsService.GetAllActionsAsync(getAllActionsRequest, context.CancellationToken);

        var actions = new List<Protos.Actions.GetAllActions.Action>();
        foreach (var action in allActions.Actions)
        {
            actions.Add(_mapper.Map<Protos.Actions.GetAllActions.Action>(action));
        }
        
        var result = new Protos.Actions.GetAllActions.GetAllActionsResponse
        {
            Actions = { actions }
        };

        return result;
    }

    public async override Task<Protos.Actions.GetSelectedActions.GetSelectedActionsResponse> getSelectedActions(Protos.Actions.GetSelectedActions.GetSelectedActionsRequest request, ServerCallContext context)
    {
        var getSelectedActionsRequest = new GetSelectedActionsRequest { Ids = request.Ids.Select(id => Guid.Parse(id)).Distinct().ToList() };

        var selectedActions = await _actionsService.GetSelectedActionsAsync(getSelectedActionsRequest, context.CancellationToken);
        
        var actions = _mapper.Map<RepeatedField<Protos.Actions.GetSelectedActions.Action>>(selectedActions.Actions);

        var result = new Protos.Actions.GetSelectedActions.GetSelectedActionsResponse
        {
            Actions = { actions }
        };

        return result;
    }
    
    public async override Task<Protos.Actions.GetAction.GetActionResponse> getAction(Protos.Actions.GetAction.GetActionRequest request, ServerCallContext context)
    {
        var result = await _actionsService.GetActionAsync(Guid.Parse(request.Id), context.CancellationToken);
        
        Console.WriteLine($"grpc:getAction: {result?.Dump()}");

        var response = _mapper.Map<Protos.Actions.GetAction.GetActionResponse>(result);

        Console.WriteLine("=====================");
        Console.WriteLine($"'Grpc:getAction:Protos': {response?.Dump()}");
        Console.WriteLine("=====================");
        
        return response;
    }

    public async override Task<Protos.Actions.CreateAction.CreateActionResponse> createAction(Protos.Actions.CreateAction.CreateActionRequest request, ServerCallContext context)
    {
        var addActionRequest = _mapper.Map<CreateActionRequest>(request);

        var result = await _actionsService.CreateActionAsync(addActionRequest, context.CancellationToken);

        var response = _mapper.Map<Protos.Actions.CreateAction.CreateActionResponse>(result);

        return response;
    }

    public async override Task<Protos.Actions.UpdateAction.UpdateActionResponse> updateAction(Protos.Actions.UpdateAction.UpdateActionRequest request, ServerCallContext context)
    {
        var updateActionRequest = _mapper.Map<UpdateActionRequest>(request);
        
        var result = await _actionsService.UpdateActionAsync(updateActionRequest, context.CancellationToken);

        var response = _mapper.Map<Protos.Actions.UpdateAction.UpdateActionResponse>(result);

        return response;
    }

    public async override Task<Protos.Actions.DeleteAction.DeleteActionResponse> deleteAction(Protos.Actions.DeleteAction.DeleteActionRequest request, ServerCallContext context)
    {
        await _actionsService.DeleteActionAsync(Guid.Parse(request.Id), context.CancellationToken);

        return new Protos.Actions.DeleteAction.DeleteActionResponse();
    }

    public async override Task<Protos.Actions.GetActionEntrySettings.GetActionEntrySettingsResponse> getActionEntrySettings(Protos.Actions.GetActionEntrySettings.GetActionEntrySettingsRequest request, ServerCallContext context)
    {
        var actionEntrySettings = await _actionsService.GetActionEntrySettings(Guid.Parse(request.Id), context.CancellationToken);

        var response = _mapper.Map<Protos.Actions.GetActionEntrySettings.GetActionEntrySettingsResponse>(actionEntrySettings);

        return response;
    }
    
    public async override Task<Protos.Actions.ImportRegistrationToActionResponse>  importRegistrationToAction(Protos.Actions.ImportRegistrationToActionRequest request, ServerCallContext context)
    {
        await _actionsService.AcceptRegistrationAsync(request.EntryId.ToGuid(), context.CancellationToken);

        return new ImportRegistrationToActionResponse();
    }

    public async override Task<Protos.Actions.AcceptPaymentResponse> acceptPayment(Protos.Actions.AcceptPaymentRequest request, ServerCallContext context)
    {
        var acceptPaymentRequest = new AcceptPaymentRequest
        {
            Id = request.Id.ToGuid(),
            Amount = request.Amount,
            Currency = request.Currency,
            ActionId = request.ActionId.ToGuid(),
            Note = request.Note,
            BankAccount = request.BankAccount
        };

        await _actionsService.AcceptPaymentAsync(acceptPaymentRequest, context.CancellationToken);

        return new Protos.Actions.AcceptPaymentResponse();
    }

    public async override Task<Protos.Actions.GetRacesForAction.GetRacesForActionResponse> getRacesForAction(Protos.Actions.GetRacesForAction.GetRacesForActionRequest request, ServerCallContext context)
    {
        var races = await _actionsService.GetRacesForActionAsync(_mapper.Map<GetRacesForActionRequest>(request), context.CancellationToken);

        return _mapper.Map<Protos.Actions.GetRacesForAction.GetRacesForActionResponse>(races);
    }

    public async override Task<Protos.Actions.GetResultsForAction.GetResultsForActionResponse> getResultsForAction(Protos.Actions.GetResultsForAction.GetResultsForActionRequest request, ServerCallContext context)
    {
        var actionResults = await _actionsService.GetResultsForActionAsync(new GetResultsForActionRequest
        {
            ActionId = request.ActionId.ToGuid()
        }, context.CancellationToken);

        return _mapper.Map<Protos.Actions.GetResultsForAction.GetResultsForActionResponse>(actionResults);
    }

    public async override Task<Empty> acceptCheckpoint(Protos.Actions.AcceptCheckpoint.AcceptCheckpointRequest request, ServerCallContext context)
    {
        await _actionsService.AcceptCheckpointAsync(_mapper.Map<AcceptCheckpointRequest>(request), context.CancellationToken);

        return new Empty();
    }
    
    public async override Task<Protos.Actions.GetPublicActionsList.GetPublicActionsListResponse> getPublicActionsList(Empty request, ServerCallContext context)
    {
        _logger.LogInformation($"{nameof(getPublicActionsList)}: Getting public actions list");

        try
        {
            var actions = await _actionsService.GetPublicActionsListAsync(new GetPublicActionsListRequest(), context.CancellationToken);

            var response = _mapper.Map<Protos.Actions.GetPublicActionsList.GetPublicActionsListResponse>(actions);

            _logger.LogInformation($"{nameof(getPublicActionsList)}: Public actions list has been retrieved: '{response.Dump()}'");

            return response;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"{nameof(getPublicActionsList)}: Error while getting public actions list");
            throw;
        }
    }
    
    public async override Task<Protos.Actions.GetSelectedPublicActionsList.GetSelectedPublicActionsListResponse> getSelectedPublicActionsList(Protos.Actions.GetSelectedPublicActionsList.GetSelectedPublicActionsListRequest request, ServerCallContext context)
    {
        var actions = await _actionsService.GetSelectedPublicActionsListAsync(new GetSelectedPublicActionsListRequest
        {
            Ids = request.Ids
                .Select(id => id.ToGuid())
                .ToList()
        }, context.CancellationToken);

        return _mapper.Map<Protos.Actions.GetSelectedPublicActionsList.GetSelectedPublicActionsListResponse>(actions);
    }
    
    public async override Task<Protos.Actions.GetSimpleActionsList.GetSimpleActionsListResponse> getSimpleActionsList(IdsRequest request, ServerCallContext context)
    {
        _logger.LogInformation($"{nameof(getSimpleActionsList)}: Getting simple actions list for ids: '{request.Ids}'");

        try
        { 
            var actions = await _actionsService.GetSimpleActionsListByTypeAsync(request.Ids.Select(id => Guid.Parse(id)).ToList(), context.CancellationToken);
            _logger.LogInformation($"{nameof(getSimpleActionsList)}: Simple actions list has been retrieved: '{actions.Dump()}'");
    
            return _mapper.Map<Protos.Actions.GetSimpleActionsList.GetSimpleActionsListResponse>(actions);
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"{nameof(getSimpleActionsList)}: Error while getting simple actions list");
            throw;
        }
    }
}