using Storage.Entities.AuthorizationRoles;
using Storage.Interfaces;
using static DogtrekkingCzShared.Entities.AuthorizationRoleDto;

namespace Storage.Seed
{
    public class StorageSeedEngine
    {
        private readonly IAuthorizationRolesService _authorizationRolesService;

        public StorageSeedEngine(IAuthorizationRolesService authorizationRolesService)
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
                    Actions = new List<ActionType>
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
                    Actions = new List<ActionType>
                    {
                        ActionType.Read, ActionType.Update, ActionType.Delete
                    }
                }, 
                CancellationToken.None);
        }
    }
}
