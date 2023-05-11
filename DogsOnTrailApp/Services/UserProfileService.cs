using DogsOnTrailApp.Models;
using SharedCode.Entities;

namespace DogsOnTrailApp.Services;

public sealed class UserProfileService : IUserProfileService
{
    private UserProfileModel _userProfileModel = new();
    
    public UserProfileModel Get()
    {
        return _userProfileModel;
    }

    public void SetUserProfile(UserProfileDto userProfile)
    {
        var rights = _userProfileModel.Rights;
        
        _userProfileModel = new UserProfileModel
        {
            Address = userProfile.Address,
            UserId = userProfile.UserId,
            Birthday = userProfile.Birthday,
            Contact = userProfile.Contact,
            Dogs = userProfile.Dogs,
            Id = userProfile.Id,
            Nickname = userProfile.Nickname,
            CompetitorId = userProfile.CompetitorId,
            FirstName = userProfile.FirstName,
            LastName = userProfile.LastName,
            Rights = rights
        };
    }
    
    public void SetRights(IList<ActionRightsDto> rights)
    {
        _userProfileModel.Rights = rights;
    }
}