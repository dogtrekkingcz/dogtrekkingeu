using Google.Protobuf.Collections;
using Grpc.Core;
using MapsterMapper;
using Protos.UserProfiles;
using Storage.Interfaces;

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
                Id = null
            };
        
        var response = _mapper.Map<Protos.UserProfiles.GetUserProfileResponse>(getUserProfileResponse);

        return response;
    }

}