using MapsterMapper;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using Storage.Entities.UserProfiles;
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
            
            var addedUserProfileRecord = await _userProfileStorageService.AddAsync(addRequest, cancellationToken);

            var response = _mapper.Map<CreateUserProfileInternalStorageResponse>(addedUserProfileRecord);

            return response;
        }

        public async Task<UpdateUserProfileInternalStorageResponse> UpdateUserProfileAsync(UpdateUserProfileInternalStorageRequest request, CancellationToken cancellationToken)
        {
            Console.WriteLine(request.ToJson());
            
            var updateRequest = _mapper.Map<UserProfileRecord>(request);
            
            Console.WriteLine(updateRequest);
            
            var result = await _userProfileStorageService.UpdateAsync(updateRequest, cancellationToken);

            return new UpdateUserProfileInternalStorageResponse
            {
                
            };
        }

        public async Task DeleteUserProfileAsync(DeleteUserProfileInternalStorageRequest request, CancellationToken cancellationToken)
        {
            await _userProfileStorageService.DeleteAsync(request.Email, cancellationToken);
        }

        public async Task<GetUserProfileInternalStorageResponse> GetUserProfileAsync(GetUserProfileInternalStorageRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"'{nameof(GetUserProfileAsync)}': Request: '{request}'");

            var filter = new List<(string key, Type typeOfValue, object value)> { ("UserId", typeof(string), request.UserId) };
            var result = await _userProfileStorageService.GetByFilterAsync(filter, cancellationToken);

            _logger.LogInformation($"'{nameof(GetUserProfileAsync)}': Response: '{result}'");

            if (result == null || result.Count == 0)
                return null;
            
            var response = _mapper.Map<GetUserProfileInternalStorageResponse>(result.First());

            return response;
        }
    }
}
