using PetsOnTrailApp.Models;

namespace PetsOnTrailApp.Services;

public interface IUserProfileService
{
    UserProfileModel Get();

    void SetUserProfile(UserProfileModel userProfile);
    
    void SetRights(IList<UserProfileModel.ActionRightsDto> rights);
}