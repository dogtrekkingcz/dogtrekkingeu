using DogtrekkingCz.Storage.Entities.UserProfiles;
using DogtrekkingCz.Storage.Models;
using MapsterMapper;
using MongoDB.Bson;
using Storage.Entities.Actions;
using Storage.Interfaces;
using Storage.Interfaces.Services;

namespace Storage.Services.Repositories
{
    internal class UserProfilesRepositoryService : IUserProfilesRepositoryService
    {
        private readonly IMapper _mapper;
        private readonly IStorageService<UserProfileRecord> _userProfileStorageService;

        public UserProfilesRepositoryService(IMapper mapper, IStorageService<UserProfileRecord> userProfileStorageService)
        {
            _mapper = mapper;
            _userProfileStorageService = userProfileStorageService;
        }

        public async Task<AddUserProfileResponse> AddUserProfileAsync(AddUserProfileRequest request, CancellationToken cancellationToken)
        {
            var addRequest = _mapper.Map<UserProfileRecord>(request);
            
            var addedActionRecord = await _userProfileStorageService.AddAsync(addRequest, cancellationToken);

            var response = new AddUserProfileResponse
            {
                
            };

            return response;
        }

        public async Task<UpdateUserProfileResponse> UpdateUserProfileAsync(UpdateUserProfileRequest request, CancellationToken cancellationToken)
        {
            Console.WriteLine(request.ToJson());
            
            var updateRequest = _mapper.Map<UserProfileRecord>(request);
            
            Console.WriteLine(updateRequest);
            
            var result = await _userProfileStorageService.UpdateAsync(updateRequest, cancellationToken);

            return new UpdateUserProfileResponse
            {
                
            };
        }

        public async Task DeleteUserProfileAsync(DeleteUserProfileRequest request, CancellationToken cancellationToken)
        {
            var deleteRequest = _mapper.Map<UserProfileRecord>(request);

            await _userProfileStorageService.DeleteAsync(deleteRequest, cancellationToken);
        }

        public async Task<GetUserProfileResponse> GetUserProfileAsync(GetUserProfileRequest request, CancellationToken cancellationToken)
        {
            var filter = new List<(string key, string value)> { ("Email", request.Email) };
            var result = await _userProfileStorageService.GetByFilterAsync(filter, cancellationToken);

            if (result == null)
                return null;
            
            var response = _mapper.Map<GetUserProfileResponse>(result.FirstOrDefault());

            return response;
        }
    }
}
