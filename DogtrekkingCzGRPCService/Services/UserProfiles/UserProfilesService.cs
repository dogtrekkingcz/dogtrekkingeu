using DogtrekkingCz.Storage.Entities.UserProfiles;
using Grpc.Core;
using MapsterMapper;
using Protos.UserProfiles;
using Storage.Interfaces;
using GetUserProfileResponse = Protos.UserProfiles.GetUserProfileResponse;
using UpdateUserProfileRequest = DogtrekkingCz.Storage.Entities.UserProfiles.UpdateUserProfileRequest;

namespace DogtrekkingCzGRPCService.Services;

public class UserProfilesService : UserProfiles.UserProfilesBase
{
    private readonly ILogger<UserProfilesService> _logger;
    private readonly IMapper _mapper;
    private readonly IUserProfilesRepositoryService _userProfilesRepositoryService;

    public UserProfilesService(ILogger<UserProfilesService> logger, IMapper mapper, IUserProfilesRepositoryService userProfilesRepositoryService)
    {
        _logger = logger;
        _mapper = mapper;
        _userProfilesRepositoryService = userProfilesRepositoryService;
    }
    
    public async override Task<Protos.UserProfiles.GetUserProfileResponse> getUserProfile(Protos.UserProfiles.GetUserProfileRequest request, ServerCallContext context)
    {
        var getUserProfileRequest = _mapper.Map<DogtrekkingCz.Storage.Entities.UserProfiles.GetUserProfileRequest>(request);
        var getUserProfileResponse = await _userProfilesRepositoryService.GetUserProfileAsync(getUserProfileRequest);

        if (getUserProfileResponse == null)
            return new GetUserProfileResponse
            {
                UserProfile = new UserProfileDto
                {
                    Id = ""                    
                }
            };
        
        var response = _mapper.Map<Protos.UserProfiles.GetUserProfileResponse>(getUserProfileResponse);

        return response;
    }

    public async override Task<Protos.UserProfiles.CreateUserProfileResponse> registerUserProfile(Protos.UserProfiles.CreateUserProfileRequest request, ServerCallContext context)
    {
        var addUserProfileRequest = _mapper.Map<AddUserProfileRequest>(request.UserProfile);
        var addUserProfileResponse = await _userProfilesRepositoryService.AddUserProfileAsync(addUserProfileRequest);

        var response = _mapper.Map<Protos.UserProfiles.CreateUserProfileResponse>(addUserProfileResponse);

        return response;
    }
    
    public async override Task<Protos.UserProfiles.UpdateUserProfileResponse> updateUserProfile(Protos.UserProfiles.UpdateUserProfileRequest request, ServerCallContext context)
    {
        var updateUserProfileRequest = _mapper.Map<UpdateUserProfileRequest>(request.UserProfile);
        var updateUserProfileResponse = await _userProfilesRepositoryService.UpdateUserProfileAsync(updateUserProfileRequest);

        var response = _mapper.Map<Protos.UserProfiles.UpdateUserProfileResponse>(updateUserProfileResponse);

        return response;
    }

}