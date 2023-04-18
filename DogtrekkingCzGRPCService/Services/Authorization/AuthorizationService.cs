using DogtrekkingCzGRPCService.Services.Actions;
using Google.Protobuf.Collections;
using Grpc.Core;
using MapsterMapper;
using Protos.Authorization;
using Storage.Interfaces;

namespace DogtrekkingCzGRPCService.Services.Authorization;

internal class AuthorizationService : Protos.Authorization.Authorization.AuthorizationBase
{
    private readonly ILogger _logger;
    private readonly IMapper _mapper;
    private readonly IActionRightsRepositoryService _actionRightsRepositoryService;

    public AuthorizationService(ILogger<AuthorizationService> logger, IMapper mapper, IActionRightsRepositoryService actionRightsRepositoryService)
    {
        _logger = logger;
        _mapper = mapper;
        _actionRightsRepositoryService = actionRightsRepositoryService;
    }

    public override async Task<GetAllRightsResponse> getAllRights(GetAllRightsRequest request, ServerCallContext context)
    {
        var rights = await _actionRightsRepositoryService.GetAllRightsAsync(new Storage.Entities.ActionRights.GetAllRightsRequest(), context.CancellationToken);

        var actionRights = _mapper.Map<RepeatedField<Protos.Shared.ActionRights>>(rights);

        var result = new GetAllRightsResponse();
        result.ActionRights.AddRange(actionRights);

        return result;
    }
}

