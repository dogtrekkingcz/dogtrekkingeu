using DogsOnTrail.Interfaces.Actions.Entities.Actions;
using DogsOnTrail.Interfaces.Actions.Services;
using DogsOnTrailGRPCService.Extensions;
using Google.Protobuf.Collections;
using Grpc.Core;
using MapsterMapper;
using Microsoft.AspNetCore.WebUtilities;
using Protos.Actions;
using SharedCode.JwtToken;
using SharedCode.Testable;
using AcceptPaymentRequest = DogsOnTrail.Interfaces.Actions.Entities.Actions.AcceptPaymentRequest;
using AcceptPaymentResponse = Protos.Actions.AcceptPaymentResponse;
using CreateActionRequest = DogsOnTrail.Interfaces.Actions.Entities.Actions.CreateActionRequest;
using GetAllActionsRequest = DogsOnTrail.Interfaces.Actions.Entities.Actions.GetAllActionsRequest;
using GetSelectedActionsRequest = DogsOnTrail.Interfaces.Actions.Entities.Actions.GetSelectedActionsRequest;
using UpdateActionRequest = DogsOnTrail.Interfaces.Actions.Entities.Actions.UpdateActionRequest;

namespace API.GRPCService.Services.Actions;

internal class ActionsService : Protos.Actions.Actions.ActionsBase, ITestableService
{
    private readonly ILogger _logger;
    private readonly IMapper _mapper;
    private readonly IJwtTokenService _jwtTokenService;
    private readonly IActionsService _actionsService;

    public ActionsService(ILogger<ActionsService> logger, IJwtTokenService jwtTokenService, IMapper mapper, IActionsService actionsService)
    {
        _logger = logger;
        _jwtTokenService = jwtTokenService;
        _mapper = mapper;
        _actionsService = actionsService;
    }

    public async override Task<Protos.Actions.GetAllActions.GetAllActionsResponse> getAllActions(Protos.Actions.GetAllActions.GetAllActionsRequest request, ServerCallContext context)
    {
        var getAllActionsRequest = _mapper.Map<GetAllActionsRequest>(request);
        
        var allActions = await _actionsService.GetAllActionsAsync(getAllActionsRequest, context.CancellationToken);

        var actions = _mapper.Map<RepeatedField<Protos.Actions.GetAllActions.Action>>(allActions.Actions);
        
        var result = new Protos.Actions.GetAllActions.GetAllActionsResponse
        {
            Actions = { actions }
        };

        return result;
    }

    public async override Task<Protos.Actions.GetSelectedActions.GetSelectedActionsResponse> getSelectedActions(Protos.Actions.GetSelectedActions.GetSelectedActionsRequest request, ServerCallContext context)
    {
        var getSelectedActionsRequest = new GetSelectedActionsRequest { Ids = request.Ids.Select(id => Guid.Parse(id)).ToList() };

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

        return _mapper.Map<Protos.Actions.GetAction.GetActionResponse>(result);
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

        return new AcceptPaymentResponse();
    }

    public async Task<TestResult> TestMeAsync()
    {
        return new TestResult { Result = true };
    }

    public TestResult TestMe()
    {
        return new TestResult { Result = true };
    }
}