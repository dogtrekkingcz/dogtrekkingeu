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
        var result = new List<Guid> { Constants.Roles.InternalAdministrator.GUID }; // TODO: Get from user data when login

        var user = await _userProfileService.GetAsync();
        if (user == null)
            return result;

        Console.WriteLine("User rights from server: " + user.Dump());

        var userRoles = user.Rights.SelectMany(right => right.Roles).ToList();
        Console.WriteLine("User roles from server: " + userRoles.Dump());

        return result;
    }
}
