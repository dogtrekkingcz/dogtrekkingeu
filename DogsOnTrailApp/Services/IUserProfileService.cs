using DogsOnTrailApp.Models;

namespace DogsOnTrailApp.Services;

public interface IUserProfileService
{
    UserProfileModel Get();

    void SetUserProfile(UserProfileModel userProfile);
    
    void SetRights(IList<UserProfileModel.ActionRightsDto> rights);
}