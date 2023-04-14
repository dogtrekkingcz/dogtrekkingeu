using DogtrekkingCz.Interfaces.Actions.Entities;
using DogtrekkingCz.Interfaces.Actions.Services;
using DogtrekkingCzShared.JwtToken;
using DogtrekkingCzShared.Testable;
using Google.Protobuf.Collections;
using Grpc.Core;
using MapsterMapper;

namespace DogtrekkingCzGRPCService.Services.Actions;

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

    public async override Task<Protos.Actions.GetAllActionsResponse> getAllActions(Protos.Actions.GetAllActionsRequest request, ServerCallContext context)
    {
        var getAllActionsRequest = _mapper.Map<GetAllActionsRequest>(request);
        
        var allActions = await _actionsService.GetAllActionsAsync(getAllActionsRequest, context.CancellationToken);

        var actions = _mapper.Map<RepeatedField<Protos.Shared.ActionSimple>>(allActions.Actions);

        var result = new Protos.Actions.GetAllActionsResponse();
        result.Actions.AddRange(actions);

        return result;
    }
    
    public async override Task<Protos.Actions.GetAllActionsDetailsResponse> getAllActionsDetails(Protos.Actions.GetAllActionsDetailsRequest request, ServerCallContext context)
    {
        var getAllActionsRequest = _mapper.Map<GetAllActionsWithDetailsRequest>(request);
        
        var allActions = await _actionsService.GetAllActionsWithDetailsAsync(getAllActionsRequest, context.CancellationToken);

        var actions = _mapper.Map<RepeatedField<Protos.Shared.ActionDetail>>(allActions.Actions);

        var result = new Protos.Actions.GetAllActionsDetailsResponse();
        result.Actions.AddRange(actions);

        return result;
    }

    public async override Task<Protos.Actions.GetActionResponse> getAction(Protos.Actions.GetActionRequest request, ServerCallContext context)
    {
        var getActionRequest = _mapper.Map<GetActionRequest>(request);

        var result = await _actionsService.GetActionAsync(getActionRequest, context.CancellationToken);

        var response = new Protos.Actions.GetActionResponse
        {
            Action = _mapper.Map<Protos.Shared.ActionDetail>(result)
        };

        return response;
    }

    public async override Task<Protos.Actions.CreateActionResponse> createAction(Protos.Actions.CreateActionRequest request, ServerCallContext context)
    {
        var addActionRequest = _mapper.Map<CreateActionRequest>(request);
        addActionRequest.Id = Guid.NewGuid().ToString();

        var result = await _actionsService.CreateActionAsync(addActionRequest, context.CancellationToken);

        var response = _mapper.Map<Protos.Actions.CreateActionResponse>(result);

        return response;
    }

    public async override Task<Protos.Actions.UpdateActionResponse> updateAction(Protos.Actions.UpdateActionRequest request, ServerCallContext context)
    {
        var updateActionRequest = _mapper.Map<UpdateActionRequest>(request.Action);
        
        var result = await _actionsService.UpdateActionAsync(updateActionRequest, context.CancellationToken);

        var response = _mapper.Map<Protos.Actions.UpdateActionResponse>(result);

        return response;
    }

    public async override Task<Protos.Actions.DeleteActionResponse> deleteAction(Protos.Actions.DeleteActionRequest request, ServerCallContext context)
    {
        var deleteActionRequest = _mapper.Map<DeleteActionRequest>(request);

        await _actionsService.DeleteActionAsync(deleteActionRequest, context.CancellationToken);

        return new Protos.Actions.DeleteActionResponse();
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