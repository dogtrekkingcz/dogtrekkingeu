using Storage.Entities.AuthorizationRoles;
using Storage.Interfaces;
using Storage.Models;

namespace Storage.Services.Repositories.AuthorizationRoles
{
    internal class AuthorizationRolesService : IAuthorizationRolesService
    {
        private IList<AuthorizationRoleRecord> _roles { get; set; }


        public AuthorizationRolesService() 
        { 

        }

        public async Task AddAuthorizationRoleAsync(AddAuthorizationRoleRequest request, CancellationToken cancellationToken)
        {
            _roles.Add(new AuthorizationRoleRecord
            {
                Id = request.Id,
                Name = request.Name,
                Actions = request.Actions
            });
        }
    }
}
