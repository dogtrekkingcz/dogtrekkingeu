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

        public UserProfilesRepositoryService(IMapper mapper, IStorageService<UserProfileRecord> actionsStorageService)
        {
            _mapper = mapper;
            _userProfileStorageService = actionsStorageService;
        }

        public async Task<AddUserProfileResponse> AddUserProfileAsync(AddUserProfileRequest request)
        {
            var addRequest = _mapper.Map<UserProfileRecord>(request);
            
            var addedActionRecord = await _userProfileStorageService.AddAsync(addRequest);

            var response = new AddUserProfileResponse
            {
                
            };

            return response;
        }

        public async Task<UpdateUserProfileResponse> UpdateUserProfileAsync(UpdateUserProfileRequest request)
        {
            Console.WriteLine(request.ToJson());
            
            var updateRequest = _mapper.Map<UserProfileRecord>(request);
            
            Console.WriteLine(updateRequest);
            
            var result = await _userProfileStorageService.UpdateAsync(updateRequest);

            return new UpdateUserProfileResponse
            {
                
            };
        }

        public async Task DeleteUserProfileAsync(DeleteUserProfileRequest request)
        {
            var deleteRequest = _mapper.Map<UserProfileRecord>(request);

            await _userProfileStorageService.DeleteAsync(deleteRequest);
        }

        public async Task<GetUserProfileResponse> GetUserProfileAsync(GetUserProfileRequest request)
        {
            var result = await _userProfileStorageService.GetByFilterAsync("Email", request.Email);

            if (result == null)
                return null;
            
            var response = _mapper.Map<GetUserProfileResponse>(result);

            return response;
        }
    }
}
