using Storage.Interfaces;
using static DogtrekkingCzShared.Entities.AuthorizationRoleDto;

namespace Storage.Seed
{
    public class SeedEngine
    {
        private readonly IAuthorizationRolesService _authorizationRolesService;

        public SeedEngine(IAuthorizationRolesService authorizationRolesService)
        {
            _authorizationRolesService = authorizationRolesService;
        }

        public async Task SeedAsync()
        {
            await _authorizationRolesService.AddAuthorizationRoleAsync(
                new Entities.AuthorizationRoles.AddAuthorizationRoleRequest
                {
                    Id = "owner",
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
