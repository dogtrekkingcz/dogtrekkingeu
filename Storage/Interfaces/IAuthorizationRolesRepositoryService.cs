using Storage.Entities.AuthorizationRoles;

namespace Storage.Interfaces
{
    public interface IAuthorizationRolesRepositoryService
    {
        public Task AddAuthorizationRoleAsync(AddAuthorizationRoleRequest request, CancellationToken cancellationToken);

        public Task<GetAllAuthorizationRolesResponse> GetAllAuthorizationRolesAsync(CancellationToken cancellationToken);

        public Task DeleteAuthorizationRoleAsync(Guid id, CancellationToken cancellationToken);
    }
}
