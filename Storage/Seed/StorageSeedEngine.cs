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
            await _authorizationRolesService.AddAuthorizationRoleAsync(
                new Entities.AuthorizationRoles.AddAuthorizationRoleRequest
                {
                    Id = AddAuthorizationRoleRequest.RoleType.User.ToString(),
                    Type = AddAuthorizationRoleRequest.RoleType.User,
                    Name = "User",
                    Actions = new List<AddAuthorizationRoleRequest.ActionType>
                    {
                        
                    }
                },
                CancellationToken.None);

            await _authorizationRolesService.AddAuthorizationRoleAsync(
                new Entities.AuthorizationRoles.AddAuthorizationRoleRequest
                {
                    Id = AddAuthorizationRoleRequest.RoleType.Owner.ToString(),
                    Type = AddAuthorizationRoleRequest.RoleType.Owner,
                    Name = "Owner",
                    Actions = new List<AddAuthorizationRoleRequest.ActionType>
                    {
                        AddAuthorizationRoleRequest.ActionType.Read, 
                        AddAuthorizationRoleRequest.ActionType.Update, 
                        AddAuthorizationRoleRequest.ActionType.Delete
                    }
                }, 
                CancellationToken.None);
        }
    }
}
