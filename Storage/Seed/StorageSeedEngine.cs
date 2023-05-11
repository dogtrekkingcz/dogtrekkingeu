using SharedCode.Entities;
using Storage.Entities.AuthorizationRoles;
using Storage.Interfaces;
using static SharedCode.Entities.AuthorizationRoleDto;

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
                    Id = AuthorizationRoleDto.RoleType.User.ToString(),
                    Type = AuthorizationRoleDto.RoleType.User,
                    Name = "User",
                    Actions = new List<ActionType>
                    {
                        
                    }
                },
                CancellationToken.None);

            await _authorizationRolesService.AddAuthorizationRoleAsync(
                new Entities.AuthorizationRoles.AddAuthorizationRoleRequest
                {
                    Id = AuthorizationRoleDto.RoleType.Owner.ToString(),
                    Type = AuthorizationRoleDto.RoleType.Owner,
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
