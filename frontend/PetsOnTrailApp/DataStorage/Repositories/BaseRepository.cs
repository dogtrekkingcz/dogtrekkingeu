namespace PetsOnTrailApp.DataStorage.Repositories;

public class BaseRepository : IBaseRepository
{
    public List<Guid> GetMyRoles() 
    { 
        return new List<Guid> { Constants.Roles.InternalAdministrator.GUID }; // TODO: Get from user data when login
    }
}
