using Storage.Entities.AuthorizationRoles;

namespace Storage.Interfaces
{
    public interface IAuthorizationRolesService
    {
        public Task AddAuthorizationRoleAsync(AddAuthorizationRoleRequest request, CancellationToken cancellationToken);
    }
}
