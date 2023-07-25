using API.GRPCService.Services.JwtToken;
using DogsOnTrail.Interfaces.Actions.Entities.UserProfile;
using DogsOnTrail.Interfaces.Actions.Services;
using Grpc.Core;
using MapsterMapper;

namespace API.GRPCService.Services.UserProfiles;

public class UserProfilesService : Protos.UserProfiles.UserProfiles.UserProfilesBase
{
    private readonly ILogger _logger;
    private readonly IMapper _mapper;
    private readonly IJwtTokenService _jwtTokenService;
    private readonly IUserProfileService _userProfileService;

    public UserProfilesService(ILogger<UserProfilesService> logger, IMapper mapper, IJwtTokenService jwtTokenService, IUserProfileService userProfileService)
    {
        _logger = logger;
        _mapper = mapper;
        _jwtTokenService = jwtTokenService;
        _userProfileService = userProfileService;
    }
    
    public async override Task<Protos.UserProfiles.GetUserProfileResponse> getUserProfile(Protos.UserProfiles.GetUserProfileRequest request, ServerCallContext context)
    {
        var getUserProfileResponse = await _userProfileService.GetUserProfileAsync(new GetUserProfileRequest(), context.CancellationToken);

        if (getUserProfileResponse == null)
            return new Protos.UserProfiles.GetUserProfileResponse { UserProfile = null };

        var response = new Protos.UserProfiles.GetUserProfileResponse
        {
            UserProfile = _mapper.Map<Protos.Shared.UserProfile>(getUserProfileResponse)
        };

        return response;
    }

    public async override Task<Protos.UserProfiles.CreateUserProfileResponse> registerUserProfile(Protos.UserProfiles.CreateUserProfileRequest request, ServerCallContext context)
    {
        var addUserProfileRequest = _mapper.Map<CreateUserProfileRequest>(request.UserProfile);

        var addUserProfileResponse = await _userProfileService.CreateUserProfileAsync(addUserProfileRequest, context.CancellationToken);

        var response = _mapper.Map<Protos.UserProfiles.CreateUserProfileResponse>(addUserProfileResponse);

        return response;
    }
    
    public async override Task<Protos.UserProfiles.UpdateUserProfileResponse> updateUserProfile(Protos.UserProfiles.UpdateUserProfileRequest request, ServerCallContext context)
    {
        var updateUserProfileRequest = _mapper.Map<UpdateUserProfileRequest>(request.UserProfile);
        var updateUserProfileResponse = await _userProfileService.UpdateUserProfileAsync(updateUserProfileRequest, context.CancellationToken);

        var response = _mapper.Map<Protos.UserProfiles.UpdateUserProfileResponse>(updateUserProfileResponse);

        return response;
    }

}