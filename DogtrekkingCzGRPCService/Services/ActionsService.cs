using Grpc.Core;
using Protos;
using Google.Protobuf.Collections;
using MapsterMapper;
using GetAllActionsRequest = Protos.GetAllActionsRequest;
using GetAllActionsResponse = Protos.GetAllActionsResponse;
using Storage.Entities.Actions;
using Storage.Interfaces;

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

    public async override Task<GetAllActionsResponse> getAllActions(GetAllActionsRequest request, ServerCallContext context)
    {
        var allActions = await _actionRepositoryService.GetAllActionsAsync();

        var result = new Protos.GetAllActionsResponse
        {
            Actions = { _mapper.Map<RepeatedField<Protos.Action>>(allActions) }
        };

        return result;
    }

    public async override Task<CreateActionResponse> createAction(CreateActionRequest request, ServerCallContext context)
    {
        var result = await _actionRepositoryService.AddActionAsync(
            new AddActionRequest
            {
                Name = request.Action.Name,
                Description = request.Action.Description,
                Owner = new AddActionRequest.OwnerRecord
                {
                    Id = request.Owner.Id,
                    Email = request.Owner.Email,
                    FirstName = request.Owner.FirstName,
                    FamilyName = request.Owner.FamilyName
                }
            });

        var response = _mapper.Map<CreateActionResponse>(result);

        return response;
    }
}