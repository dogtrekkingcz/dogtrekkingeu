using PetsOnTrail.Interfaces.Actions.Entities.UserProfile;
using PetsOnTrail.Interfaces.Actions.Services;
using Grpc.Core;
using MapsterMapper;
using GetUserProfileRequest = PetsOnTrail.Interfaces.Actions.Entities.UserProfile.GetUserProfileRequest;
using PetsOnTrail.Interfaces.Actions.Entities.JwtToken;

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
    
    public async override Task<Protos.UserProfiles.GetUserProfile.GetUserProfileResponse> getUserProfile(Protos.UserProfiles.GetUserProfile.GetUserProfileRequest request, ServerCallContext context)
    {
        var getUserProfileResponse = await _userProfileService.GetUserProfileAsync(new GetUserProfileRequest(), context.CancellationToken);

        if (getUserProfileResponse == null || string.IsNullOrEmpty(getUserProfileResponse.Id))
            return new Protos.UserProfiles.GetUserProfile.GetUserProfileResponse
            {
                Id = string.Empty
            };
        
        var response = _mapper.Map<Protos.UserProfiles.GetUserProfile.GetUserProfileResponse>(getUserProfileResponse);

        return response;
    }

    public async override Task<Protos.UserProfiles.CreateUserProfile.CreateUserProfileResponse> registerUserProfile(Protos.UserProfiles.CreateUserProfile.CreateUserProfileRequest request, ServerCallContext context)
    {
        var addUserProfileRequest = _mapper.Map<CreateUserProfileRequest>(request);

        var addUserProfileResponse = await _userProfileService.CreateUserProfileAsync(addUserProfileRequest, context.CancellationToken);

        var response = _mapper.Map<Protos.UserProfiles.CreateUserProfile.CreateUserProfileResponse>(addUserProfileResponse);

        return response;
    }
    
    public async override Task<Protos.UserProfiles.UpdateUserProfile.UpdateUserProfileResponse> updateUserProfile(Protos.UserProfiles.UpdateUserProfile.UpdateUserProfileRequest request, ServerCallContext context)
    {
        var updateUserProfileRequest = _mapper.Map<UpdateUserProfileRequest>(request);
        var updateUserProfileResponse = await _userProfileService.UpdateUserProfileAsync(updateUserProfileRequest, context.CancellationToken);

        var response = _mapper.Map<Protos.UserProfiles.UpdateUserProfile.UpdateUserProfileResponse>(updateUserProfileResponse);

        return response;
    }

    public async override Task<Protos.UserProfiles.GetSelectedSurnameName.GetSelectedSurnameNameResponse> getSelectedSurnameName(Protos.UserProfiles.GetSelectedSurnameName.GetSelectedSurnameNameRequest request, ServerCallContext context)
    {
        var selectedUsers = await _userProfileService.GetSelectedSurnameNameAsync(new GetSelectedSurnameNameRequest { Ids = request.Ids.ToList() }, context.CancellationToken);

        var response = new Protos.UserProfiles.GetSelectedSurnameName.GetSelectedSurnameNameResponse
        {
            Items =
            {
                selectedUsers.Items.Select(su =>
                    _mapper.Map<Protos.UserProfiles.GetSelectedSurnameName.SelectedSurnameName>(su)).ToList()
            }
        };

        return response;
    }
}