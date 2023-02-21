using DogtrekkingCz.Storage.Entities.UserProfiles;

namespace Storage.Interfaces
{
    public interface IUserProfilesRepositoryService : IRepositoryService
    {
        public Task<AddUserProfileResponse> AddUserProfileAsync(AddUserProfileRequest request);

        public Task<UpdateUserProfileResponse> UpdateUserProfileAsync(UpdateUserProfileRequest request);

        public Task<GetUserProfileResponse> GetUserProfileAsync(GetUserProfileRequest request);
        
        public Task DeleteUserProfileAsync(DeleteUserProfileRequest request);
    }
}
