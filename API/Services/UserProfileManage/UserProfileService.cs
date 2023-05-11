using DogsOnTrail.Interfaces.Actions.Entities.UserProfile;
using DogsOnTrail.Interfaces.Actions.Services;
using SharedCode.JwtToken;
using MapsterMapper;
using Storage.Entities.UserProfiles;
using Storage.Interfaces;

namespace DogsOnTrail.Actions.Services.UserProfileManage
{
    internal class UserProfileService : IUserProfileService
    {
        private readonly IMapper _mapper;
        private readonly IUserProfilesRepositoryService _userProfilesRepositoryService;
        private readonly IJwtTokenService _jwtTokenService;

        public UserProfileService(IMapper mapper, IUserProfilesRepositoryService userProfilesRepositoryService, IJwtTokenService jwtTokenService) 
        { 
            _mapper = mapper;
            _userProfilesRepositoryService = userProfilesRepositoryService;
            _jwtTokenService = jwtTokenService;
        }

        public async Task<CreateUserProfileResponse> CreateUserProfileAsync(CreateUserProfileRequest request, CancellationToken cancellationToken)
        {
            var addUserProfileRequest = _mapper.Map<AddUserProfileInternalStorageRequest>(request) with
            {
                UserId = _jwtTokenService.GetUserId()
            };

            await _userProfilesRepositoryService.AddUserProfileAsync(addUserProfileRequest, cancellationToken);

            return new CreateUserProfileResponse();
        }

        public async Task<GetUserProfileResponse> GetUserProfileAsync(GetUserProfileRequest request, CancellationToken cancellationToken)
        {
            var getUserProfileRequest = _mapper.Map<GetUserProfileInternalStorageRequest>(request) with
            {
                UserId = _jwtTokenService.GetUserId()
            };

            var result = await _userProfilesRepositoryService.GetUserProfileAsync(getUserProfileRequest, cancellationToken);

            var response = _mapper.Map<GetUserProfileResponse>(result);

            return response;
        }

        public async Task<UpdateUserProfileResponse> UpdateUserProfileAsync(UpdateUserProfileRequest request, CancellationToken cancellationToken)
        {
            var updateUserProfileRequest = _mapper.Map<UpdateUserProfileInternalStorageRequest>(request);

            await _userProfilesRepositoryService.UpdateUserProfileAsync(updateUserProfileRequest, cancellationToken);

            return new UpdateUserProfileResponse();
        }
    }
}
