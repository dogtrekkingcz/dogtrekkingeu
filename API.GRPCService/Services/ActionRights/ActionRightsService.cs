using API.GRPCService.Services.JwtToken;
using PetsOnTrail.Interfaces.Actions.Entities.Rights;
using PetsOnTrail.Interfaces.Actions.Services;
using Grpc.Core;
using MapsterMapper;
using Protos.ActionRights.GetActionRights;

namespace API.GRPCService.Services.ActionRights;

internal class ActionRightsService : Protos.ActionRights.ActionRights.ActionRightsBase
{
    private readonly ILogger _logger;
    private readonly IMapper _mapper;
    private readonly IJwtTokenService _jwtTokenService;
    private readonly IRightsService _rightsService;

    public ActionRightsService(ILogger<ActionRightsService> logger, IMapper mapper, IJwtTokenService jwtTokenService, IRightsService rightsService)
    {
        _logger = logger;
        _mapper = mapper;
        _jwtTokenService = jwtTokenService;
        _rightsService = rightsService;
    }

    public override async Task<Protos.ActionRights.GetActionRights.GetActionRightsResponse> getActionRights(Protos.ActionRights.GetActionRights.GetActionRightsRequest request, ServerCallContext context)
    {
        var userId = _jwtTokenService.GetUserId();
        
        var rights = await _rightsService.GetAllRightsAsync(new GetAllRightsRequest { UserId = userId }, context.CancellationToken);

        var result = _mapper.Map<GetActionRightsResponse>(rights);

        return result;
    }
}

