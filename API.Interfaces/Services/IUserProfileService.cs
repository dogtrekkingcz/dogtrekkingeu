using DogsOnTrail.Interfaces.Actions.Entities.UserProfile;

namespace DogsOnTrail.Interfaces.Actions.Services
{
    public interface IUserProfileService
    {
        Task<CreateUserProfileResponse> CreateUserProfileAsync(CreateUserProfileRequest request, CancellationToken cancellationToken);

        Task<GetUserProfileResponse> GetUserProfileAsync(GetUserProfileRequest request, CancellationToken cancellationToken);

        Task<UpdateUserProfileResponse> UpdateUserProfileAsync(UpdateUserProfileRequest request, CancellationToken cancellationToken);
    }
}
