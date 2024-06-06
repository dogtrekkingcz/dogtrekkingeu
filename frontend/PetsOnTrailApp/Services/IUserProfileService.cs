using PetsOnTrailApp.Models;
using SharedLib.Models;

namespace PetsOnTrailApp.Services;

public interface IUserProfileService
{
    Task<UserProfileModel> GetAsync();

    Task<UserActivitiesModel> GetUserActivitiesAsync(Guid userId, CancellationToken cancellationToken);

    void Invalidate();
}