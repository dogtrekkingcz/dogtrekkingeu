using Storage.Entities.AuthorizationRoles;
using Storage.Interfaces;

namespace Storage.Seed
{
    public class StorageSeedEngine
    {
        private readonly IAuthorizationRolesRepositoryService _authorizationRolesService;
        
        public StorageSeedEngine(IAuthorizationRolesRepositoryService authorizationRolesService)
        {
            _authorizationRolesService = authorizationRolesService;
        }

        public async Task SeedAsync()
        {

        }
    }
}
