using DogtrekkingCzApp.Models;
using DogtrekkingCzShared.Entities;

namespace DogtrekkingCzApp.Services;

public interface IUserProfileService
{
    UserProfileModel Get();

    void SetUserProfile(UserProfileDto userProfile);
    
    void SetRights(IList<ActionRightsDto> rights);
}