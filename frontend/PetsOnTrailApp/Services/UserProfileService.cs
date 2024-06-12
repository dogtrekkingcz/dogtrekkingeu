using MapsterMapper;
using PetsOnTrailApp.Models;
using PetsOnTrailApp.Providers;
using Protos.UserProfiles.GetUserProfile;
using SharedLib.Models;

namespace PetsOnTrailApp.Services;

public sealed class UserProfileService : IUserProfileService
{
    private UserProfileModel _userProfileModel = new();

    private readonly Protos.ActionRights.ActionRights.ActionRightsClient _actionRightsClient;
    private readonly Protos.UserProfiles.UserProfiles.UserProfilesClient _userProfilesClient;
    private readonly IServiceProvider _serviceProvider;
    private readonly TokenStorage _tokenStorage;

    private DateTimeOffset? IsValidTime { get; set; } = null;

    public UserProfileService(
        Protos.ActionRights.ActionRights.ActionRightsClient actionRightsClient, 
        Protos.UserProfiles.UserProfiles.UserProfilesClient userProfilesClient,
        TokenStorage tokenStorage,
        IServiceProvider serviceProvider)
    {
        _actionRightsClient = actionRightsClient;
        _userProfilesClient = userProfilesClient;
        _serviceProvider = serviceProvider;
        _tokenStorage = tokenStorage;
    }

    public async Task<UserProfileModel> GetAsync()
    {   
        if (string.IsNullOrWhiteSpace(await _tokenStorage.GetAccessToken()))
            return null;

        if (IsValidTime != null && IsValidTime > DateTimeOffset.Now.AddMinutes(-5))
            return _userProfileModel;
                
        try
        {
            var userProfile = await _userProfilesClient.getUserProfileAsync(new GetUserProfileRequest());
            if (userProfile == null || userProfile.Id == string.Empty)
            {
                IsValidTime = DateTimeOffset.Now;
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
                    Id = Guid.Parse(right.Id),
                    ActionId = Guid.Parse(right.ActionId),
                    UserId = Guid.Parse(right.UserId),
                    Roles = right.Roles.Select(role => Guid.Parse(role)).ToList()
                });
            }

            SetRights(userRights);

            IsValidTime = DateTimeOffset.Now;

            return _userProfileModel;
        }
        catch (Exception ex)
        {
            IsValidTime = DateTimeOffset.Now;
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