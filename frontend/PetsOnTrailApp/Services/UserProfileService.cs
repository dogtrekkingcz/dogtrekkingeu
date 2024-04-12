using MapsterMapper;
using Protos.UserProfiles.GetUserProfile;
using SharedLib.Models;

namespace PetsOnTrailApp.Services;

public sealed class UserProfileService : IUserProfileService
{
    private UserProfileModel _userProfileModel = new();

    private readonly Protos.ActionRights.ActionRights.ActionRightsClient _actionRightsClient;
    private readonly Protos.UserProfiles.UserProfiles.UserProfilesClient _userProfilesClient;
    private readonly IServiceProvider _serviceProvider;

    private DateTimeOffset? IsValidTime { get; set; } = null;

    private bool IsRunning { get; set; } = false;

    public UserProfileService(
        Protos.ActionRights.ActionRights.ActionRightsClient actionRightsClient, 
        Protos.UserProfiles.UserProfiles.UserProfilesClient userProfilesClient,
        IServiceProvider serviceProvider)
    {
        _actionRightsClient = actionRightsClient;
        _userProfilesClient = userProfilesClient;
        _serviceProvider = serviceProvider;
    }
    
    public async Task<UserProfileModel> GetAsync()
    {
        while (IsRunning)
            await Task.Delay(100);
        
        if (IsValidTime != null && IsValidTime > DateTimeOffset.Now.AddMinutes(-5))
            return _userProfileModel;

        IsRunning = true;
        
        try
        {
            var userProfile = await _userProfilesClient.getUserProfileAsync(new GetUserProfileRequest());
            if (userProfile == null || userProfile.Id == string.Empty)
            {
                IsRunning = false;
                return null;
            }

            using (var scope = _serviceProvider.CreateScope())
            {
                var mapper = scope.ServiceProvider.GetRequiredService<IMapper>();
                SetUserProfile(mapper.Map<UserProfileModel>(userProfile));
            }

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

            IsRunning = false;

            return _userProfileModel;
        }
        catch (Exception ex)
        {
            IsRunning = false;
            return null;
        }
    }

    public void Invalidate()
    {
        IsValidTime = null;
    }

    public void SetUserProfile(UserProfileModel userProfileModel)
    {
        var rights = _userProfileModel.Rights;
        
        using (var scope = _serviceProvider.CreateScope())
        {
            var mapper = scope.ServiceProvider.GetRequiredService<IMapper>();
            
            _userProfileModel = mapper.Map<UserProfileModel>(userProfileModel)
                with
                {
                    Rights = rights
                };
        }
    }
    
    public void SetRights(IList<UserProfileModel.ActionRightsDto> rights)
    {
        _userProfileModel.Rights = rights;
    }
}