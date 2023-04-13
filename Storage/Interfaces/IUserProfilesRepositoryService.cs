using Storage.Entities.UserProfiles;

namespace Storage.Interfaces
{
    public interface IUserProfilesRepositoryService : IRepositoryService
    {
        public Task<AddUserProfileResponse> AddUserProfileAsync(AddUserProfileRequest request, CancellationToken cancellationToken);

        public Task<UpdateUserProfileResponse> UpdateUserProfileAsync(UpdateUserProfileRequest request, CancellationToken cancellationToken);

        public Task<GetUserProfileResponse> GetUserProfileAsync(GetUserProfileRequest request, CancellationToken cancellationToken);
        
        public Task DeleteUserProfileAsync(DeleteUserProfileRequest request, CancellationToken cancellationToken);
    }
}
