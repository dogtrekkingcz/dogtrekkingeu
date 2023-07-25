using DogsOnTrail.Interfaces.Actions.Entities.Rights;
using DogsOnTrail.Interfaces.Actions.Services;
using Google.Protobuf.Collections;
using Grpc.Core;
using MapsterMapper;
using SharedCode.JwtToken;

namespace API.GRPCService.Services.Authorization;

internal class AuthorizationService : Protos.Authorization.Authorization.AuthorizationBase
{
    private readonly ILogger _logger;
    private readonly IMapper _mapper;
    private readonly IJwtTokenService _jwtTokenService;
    private readonly IRightsService _rightsService;

    public AuthorizationService(ILogger<AuthorizationService> logger, IMapper mapper, IJwtTokenService jwtTokenService, IRightsService rightsService)
    {
        _logger = logger;
        _mapper = mapper;
        _jwtTokenService = jwtTokenService;
        _rightsService = rightsService;
    }

    public override async Task<Protos.Authorization.GetAllRightsResponse> getAllRights(Protos.Authorization.GetAllRightsRequest request, ServerCallContext context)
    {
        var userId = _jwtTokenService.GetUserId();
        
        var rights = await _rightsService.GetAllRightsAsync(new GetAllRightsRequest { UserId = userId }, context.CancellationToken);

        var actionRights = _mapper.Map<RepeatedField<Protos.Shared.ActionRights>>(rights);

        var result = new Protos.Authorization.GetAllRightsResponse();
        result.ActionRights.AddRange(actionRights);

        return result;
    }
}

