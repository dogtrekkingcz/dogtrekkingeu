using MapsterMapper;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using Storage.Entities.UserProfiles;
using Storage.Extensions;
using Storage.Interfaces;
using Storage.Models;

namespace Storage.Services.Repositories.UserProfiles
{
    internal class UserProfilesRepositoryService : IUserProfilesRepositoryService
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IStorageService<UserProfileRecord> _userProfileStorageService;

        public UserProfilesRepositoryService(ILogger<UserProfilesRepositoryService> logger, IMapper mapper, IStorageService<UserProfileRecord> userProfileStorageService)
        {
            _logger = logger;
            _mapper = mapper;
            _userProfileStorageService = userProfileStorageService;
        }

        public async Task<CreateUserProfileInternalStorageResponse> AddUserProfileAsync(CreateUserProfileInternalStorageRequest request, CancellationToken cancellationToken)
        {
            var addRequest = _mapper.Map<UserProfileRecord>(request);
            
            var addedUserProfileRecord = await _userProfileStorageService.AddOrUpdateAsync(addRequest, cancellationToken);

            var response = _mapper.Map<CreateUserProfileInternalStorageResponse>(addedUserProfileRecord);

            return response;
        }

        public async Task<UpdateUserProfileInternalStorageResponse> UpdateUserProfileAsync(UpdateUserProfileInternalStorageRequest request, CancellationToken cancellationToken)
        {
            var updateRequest = _mapper.Map<UserProfileRecord>(request);
            
            var result = await _userProfileStorageService.AddOrUpdateAsync(updateRequest, cancellationToken);

            return _mapper.Map<UpdateUserProfileInternalStorageResponse>(result);
        }

        public async Task DeleteUserProfileAsync(DeleteUserProfileInternalStorageRequest request, CancellationToken cancellationToken)
        {
            await _userProfileStorageService.DeleteAsync(request.Id, cancellationToken);
        }

        public async Task<GetUserProfileInternalStorageResponse> GetUserProfileAsync(GetUserProfileInternalStorageRequest request, CancellationToken cancellationToken)
        {
            var filter = new List<(string key, Type typeOfValue, object value)> { ("UserId", typeof(string), request.UserId) };
            var result = await _userProfileStorageService.GetByFilterAsync(filter, cancellationToken);

            if (result == null || result.Count == 0)
                return null;
            
            var response = _mapper.Map<GetUserProfileInternalStorageResponse>(result.First());

            return response;
        }

        public async Task<GetSelectedUserProfilesInternalStorageResponse> GetSelectedUserProfiles(GetSelectedUserProfilesInternalStorageRequest request, CancellationToken cancellationToken)
        {
            var selectedUsers = await _userProfileStorageService.GetSelectedListAsync("UserId", request.Ids, cancellationToken);

            var response = new GetSelectedUserProfilesInternalStorageResponse
            {
                Items = selectedUsers.Select(su =>
                    _mapper.Map<GetSelectedUserProfilesInternalStorageResponse.UserProfileDto>(su)).ToList()
            };

            return response;
        }
    }
}
