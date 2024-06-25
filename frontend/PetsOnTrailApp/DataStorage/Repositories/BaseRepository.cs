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

    public List<Guid> GetMyRoles() 
    {
        var user = _userProfileService.GetAsync().Result;
        var userRoles = user.Rights.SelectMany(right => right.Roles).ToList();

        Console.WriteLine("User roles from server: " + userRoles.Dump());


        return new List<Guid> { Constants.Roles.InternalAdministrator.GUID }; // TODO: Get from user data when login
    }
}
