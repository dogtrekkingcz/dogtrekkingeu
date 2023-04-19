using Storage.Entities.UserProfiles;

namespace Storage.Interfaces
{
    public interface IUserProfilesRepositoryService : IRepositoryService
    {
        public Task<AddUserProfileInternalStorageResponse> AddUserProfileAsync(AddUserProfileInternalStorageRequest request, CancellationToken cancellationToken);

        public Task<UpdateUserProfileInternalStorageResponse> UpdateUserProfileAsync(UpdateUserProfileInternalStorageRequest request, CancellationToken cancellationToken);

        public Task<GetUserProfileInternalStorageResponse> GetUserProfileAsync(GetUserProfileInternalStorageRequest request, CancellationToken cancellationToken);
        
        public Task DeleteUserProfileAsync(DeleteUserProfileInternalStorageRequest request, CancellationToken cancellationToken);
    }
}
