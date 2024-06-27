using PetsOnTrailApp.Extensions;
using PetsOnTrailApp.Services;
using static Protos.Actions.Actions;

namespace PetsOnTrailApp.DataStorage.Repositories;

public class BaseRepository : IBaseRepository
{
    public ActionsClient ActionsClientInstance { get; init; }
    private readonly IUserProfileService _userProfileService;

    public BaseRepository(ActionsClient actionsClient, IUserProfileService userProfileService)
    {
        ActionsClientInstance = actionsClient;
        _userProfileService = userProfileService;
    }

    public async Task<List<Guid>> GetMyRolesAsync() 
    {
        var result = new List<Guid> { };

        var user = await _userProfileService.GetAsync();
        if (user == null)
            return result;

        return user.Roles;
    }
}
