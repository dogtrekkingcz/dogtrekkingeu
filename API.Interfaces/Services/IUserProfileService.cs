using PetsOnTrail.Interfaces.Actions.Entities.UserProfile;

namespace PetsOnTrail.Interfaces.Actions.Services
{
    public interface IUserProfileService
    {
        Task<CreateUserProfileResponse> CreateUserProfileAsync(CreateUserProfileRequest request, CancellationToken cancellationToken);

        Task<GetUserProfileResponse> GetUserProfileAsync(GetUserProfileRequest request, CancellationToken cancellationToken);

        Task<UpdateUserProfileResponse> UpdateUserProfileAsync(UpdateUserProfileRequest request, CancellationToken cancellationToken);
        
        Task<GetSelectedSurnameNameResponse> GetSelectedSurnameNameAsync(GetSelectedSurnameNameRequest request, CancellationToken cancellationToken);
    }
}
