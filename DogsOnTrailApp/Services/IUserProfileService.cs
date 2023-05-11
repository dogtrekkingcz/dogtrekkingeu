using DogsOnTrailApp.Models;
using SharedCode.Entities;

namespace DogsOnTrailApp.Services;

public interface IUserProfileService
{
    UserProfileModel Get();

    void SetUserProfile(UserProfileDto userProfile);
    
    void SetRights(IList<ActionRightsDto> rights);
}