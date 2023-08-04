using PetsOnTrailApp.Models;

namespace PetsOnTrailApp.Services;

public interface IUserProfileService
{
    Task<UserProfileModel> GetAsync();

    void Invalidate();
}