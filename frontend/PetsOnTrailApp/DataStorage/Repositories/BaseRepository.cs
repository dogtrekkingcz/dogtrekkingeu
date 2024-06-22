using static Protos.Actions.Actions;

namespace PetsOnTrailApp.DataStorage.Repositories;

public class BaseRepository : IBaseRepository
{
    public ActionsClient ActionsClientInstance { get; init; }

    public BaseRepository(ActionsClient actionsClient)
    {
        ActionsClientInstance = actionsClient;
    }

    public List<Guid> GetMyRoles() 
    { 
        return new List<Guid> { Constants.Roles.InternalAdministrator.GUID }; // TODO: Get from user data when login
    }
}
