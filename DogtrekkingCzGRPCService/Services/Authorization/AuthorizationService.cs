using Grpc.Core;
using Google.Protobuf.Collections;
using MapsterMapper;
using Protos.Authorization;
using DogtrekkingCzGRPCService.Services.JwtToken;
using Storage.Interfaces;

namespace DogtrekkingCzGRPCService.Services;

internal class AuthorizationService : Authorization.AuthorizationBase
{
    private readonly ILogger<ActionsService> _logger;
    private readonly IMapper _mapper;
    private readonly IActionRightsRepositoryService _actionRightsRepositoryService;

    public AuthorizationService(ILogger<ActionsService> logger, IMapper mapper, IActionRightsRepositoryService actionRightsRepositoryService)
    {
        _logger = logger;
        _mapper = mapper;
        _actionRightsRepositoryService = actionRightsRepositoryService;
    }

    public override async Task<GetAllRightsResponse> getAllRights(GetAllRightsRequest request, ServerCallContext context)
    {
        var rights = await _actionRightsRepositoryService.GetAllRightsAsync(new Storage.Entities.ActionRights.GetAllRightsRequest());


        var actionRights = _mapper.Map<RepeatedField<Protos.Shared.ActionRights>>(rights);

        var result = new GetAllRightsResponse();
        result.ActionRights.AddRange(actionRights);

        return result;
    }
}

