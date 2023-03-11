using Grpc.Core;
using Google.Protobuf.Collections;
using MapsterMapper;
using Protos.Actions;
using Storage.Entities.Actions;
using Storage.Interfaces;
using DeleteActionRequest = Storage.Entities.Actions.DeleteActionRequest;
using GetActionRequest = Storage.Entities.Actions.GetActionRequest;

namespace DogtrekkingCzGRPCService.Services;

public class ActionsService : Actions.ActionsBase
{
    private readonly ILogger<ActionsService> _logger;
    private readonly IMapper _mapper;
    private readonly IActionsRepositoryService _actionRepositoryService;

    public ActionsService(ILogger<ActionsService> logger, IMapper mapper, IActionsRepositoryService actionsRepositoryService)
    {
        _logger = logger;
        _mapper = mapper;
        _actionRepositoryService = actionsRepositoryService;
    }

    public async override Task<Protos.Actions.GetAllActionsResponse> getAllActions(Protos.Actions.GetAllActionsRequest request, ServerCallContext context)
    {
        var allActions = await _actionRepositoryService.GetAllActionsAsync();

        var actions = _mapper.Map<RepeatedField<Protos.Actions.ActionDto>>(allActions.Actions);

        var result = new Protos.Actions.GetAllActionsResponse();
        result.Actions.AddRange(actions);

        return result;
    }
    
    public async override Task<Protos.Actions.GetAllActionsDetailsResponse> getAllActionsDetails(Protos.Actions.GetAllActionsDetailsRequest request, ServerCallContext context)
    {
        var allActions = await _actionRepositoryService.GetAllActionsAsync();

        var actions = _mapper.Map<RepeatedField<Protos.Actions.ActionDetailDto>>(allActions.Actions);

        var result = new Protos.Actions.GetAllActionsDetailsResponse();
        result.Actions.AddRange(actions);

        return result;
    }

    public async override Task<Protos.Actions.GetActionResponse> getAction(Protos.Actions.GetActionRequest request, ServerCallContext context)
    {
        var getActionRequest = _mapper.Map<GetActionRequest>(request);

        var result = await _actionRepositoryService.GetActionAsync(getActionRequest);

        var response = new Protos.Actions.GetActionResponse
        {
            Action = _mapper.Map<Protos.Actions.ActionDto>(result)
        };

        return response;
    }

    public async override Task<CreateActionResponse> createAction(CreateActionRequest request, ServerCallContext context)
    {
        var addActionRequest = _mapper.Map<AddActionRequest>(request.Action);

        var result = await _actionRepositoryService.AddActionAsync(addActionRequest);

        var response = _mapper.Map<CreateActionResponse>(result);

        return response;
    }

    public async override Task<Protos.Actions.UpdateActionResponse> updateAction(Protos.Actions.UpdateActionRequest request, ServerCallContext context)
    {
        var updateActionRequest = _mapper.Map<Storage.Entities.Actions.UpdateActionRequest>(request.Action);
        
        var result = await _actionRepositoryService.UpdateActionAsync(updateActionRequest);

        var response = _mapper.Map<Protos.Actions.UpdateActionResponse>(result);

        return response;
    }

    public async override Task<DeleteActionResponse> deleteAction(Protos.Actions.DeleteActionRequest request, ServerCallContext context)
    {
        var deleteActionRequest = _mapper.Map<DeleteActionRequest>(request);

        await _actionRepositoryService.DeleteActionAsync(deleteActionRequest);

        return new DeleteActionResponse();
    }
}