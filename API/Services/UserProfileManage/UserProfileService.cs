using PetsOnTrail.Interfaces.Actions.Entities.UserProfile;
using PetsOnTrail.Interfaces.Actions.Services;
using MapsterMapper;
using Storage.Entities.UserProfiles;
using Storage.Interfaces;

namespace PetsOnTrail.Actions.Services.UserProfileManage
{
    internal class UserProfileService : IUserProfileService
    {
        private readonly IMapper _mapper;
        private readonly IUserProfilesRepositoryService _userProfilesRepositoryService;
        private readonly ICurrentUserIdService _currentUserIdService;

        public UserProfileService(IMapper mapper, IUserProfilesRepositoryService userProfilesRepositoryService, ICurrentUserIdService currentUserIdService) 
        { 
            _mapper = mapper;
            _userProfilesRepositoryService = userProfilesRepositoryService;
            _currentUserIdService = currentUserIdService;
        }

        public async Task<CreateUserProfileResponse> CreateUserProfileAsync(CreateUserProfileRequest request, CancellationToken cancellationToken)
        {
            var createUserProfileRequest = _mapper.Map<CreateUserProfileInternalStorageRequest>(request) with
            {
                UserId = _currentUserIdService.GetUserId(),
                Roles = new List<Guid> { Constants.Roles.InternalUser.GUID }
            };

            await _userProfilesRepositoryService.AddUserProfileAsync(createUserProfileRequest, cancellationToken);

            return new CreateUserProfileResponse();
        }

        public async Task<GetUserProfileResponse> GetUserProfileAsync(GetUserProfileRequest request, CancellationToken cancellationToken)
        {
            var getUserProfileRequest = _mapper.Map<GetUserProfileInternalStorageRequest>(request) with
            {
                UserId = _currentUserIdService.GetUserId()
            };

            var result = await _userProfilesRepositoryService.GetUserProfileAsync(getUserProfileRequest, cancellationToken);
            if (result == null)
                return new GetUserProfileResponse
                {
                    Id = null
                };

            var response = _mapper.Map<GetUserProfileResponse>(result);

            return response;
        }

        public async Task<UpdateUserProfileResponse> UpdateUserProfileAsync(UpdateUserProfileRequest request, CancellationToken cancellationToken)
        {
            var updateUserProfileRequest = _mapper.Map<UpdateUserProfileInternalStorageRequest>(request);

            await _userProfilesRepositoryService.UpdateUserProfileAsync(updateUserProfileRequest, cancellationToken);

            return new UpdateUserProfileResponse();
        }

        public async Task<GetSelectedSurnameNameResponse> GetSelectedSurnameNameAsync(GetSelectedSurnameNameRequest request, CancellationToken cancellationToken)
        {
            var selectedUsers = await _userProfilesRepositoryService.GetSelectedUserProfiles(new GetSelectedUserProfilesInternalStorageRequest { Ids = request.Ids }, cancellationToken);

            var response = new GetSelectedSurnameNameResponse
            {
                Items = selectedUsers.Items
                    .Select(su => _mapper.Map<GetSelectedSurnameNameResponse.SelectedSurnameNameDto>(su))
                    .ToList()
            };

            return response;
        }
    }
}
