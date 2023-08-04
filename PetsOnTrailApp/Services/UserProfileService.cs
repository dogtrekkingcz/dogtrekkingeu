using PetsOnTrailApp.Models;
using MapsterMapper;
using Protos.UserProfiles.GetUserProfile;

namespace PetsOnTrailApp.Services;

public sealed class UserProfileService : IUserProfileService
{
    private UserProfileModel _userProfileModel = new();

    private readonly IMapper _mapper;
    private readonly Protos.ActionRights.ActionRights.ActionRightsClient _actionRightsClient;
    private readonly Protos.UserProfiles.UserProfiles.UserProfilesClient _userProfilesClient;

    private DateTimeOffset? IsValidTime { get; set; } = null;

    public UserProfileService(
        IMapper mapper, 
        Protos.ActionRights.ActionRights.ActionRightsClient actionRightsClient, 
        Protos.UserProfiles.UserProfiles.UserProfilesClient userProfilesClient)
    {
        _mapper = mapper;
        _actionRightsClient = actionRightsClient;
        _userProfilesClient = userProfilesClient;
    }
    
    public async Task<UserProfileModel> GetAsync()
    {
        if (IsValidTime != null && IsValidTime > DateTimeOffset.Now.AddMinutes(-5))
            return _userProfileModel;
        
        var userProfile = await _userProfilesClient.getUserProfileAsync(new GetUserProfileRequest());

        if (userProfile == null || userProfile.Id == string.Empty)
            return null;

        SetUserProfile(_mapper.Map<UserProfileModel>(userProfile));
        
        var getActionRightsResponse = await _actionRightsClient.getActionRightsAsync(
            new Protos.ActionRights.GetActionRights.GetActionRightsRequest
            {
                Id = ""
            });

        var userRights = new List<UserProfileModel.ActionRightsDto>();
        foreach (var right in getActionRightsResponse.Rights)
        {
            userRights.Add(new UserProfileModel.ActionRightsDto
            {
                Id = right.Id,
                ActionId = right.ActionId,
                UserId = right.UserId,
                Roles = right.Roles
            });
        }

        SetRights(userRights);
        
        IsValidTime = DateTimeOffset.Now;

        return _userProfileModel;
    }

    public void Invalidate()
    {
        IsValidTime = null;
    }

    public void SetUserProfile(UserProfileModel userProfileModel)
    {
        var rights = _userProfileModel.Rights;
        
        _userProfileModel = _mapper.Map<UserProfileModel>(userProfileModel)
            with
            {
                Rights = rights
            };
    }
    
    public void SetRights(IList<UserProfileModel.ActionRightsDto> rights)
    {
        _userProfileModel.Rights = rights;
    }
}