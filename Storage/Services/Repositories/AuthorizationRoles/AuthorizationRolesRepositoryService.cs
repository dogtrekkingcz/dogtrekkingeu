using MapsterMapper;
using Microsoft.Extensions.Logging;
using Storage.Entities.AuthorizationRoles;
using Storage.Interfaces;
using Storage.Models;
using Storage.Services.Repositories.UserProfiles;

namespace Storage.Services.Repositories.AuthorizationRoles
{
    internal class AuthorizationRolesRepositoryService : IAuthorizationRolesRepositoryService
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IStorageService<AuthorizationRoleRecord> _authorizationRoleStorageService;

        public AuthorizationRolesRepositoryService(ILogger<AuthorizationRolesRepositoryService> logger, IMapper mapper, IStorageService<AuthorizationRoleRecord> authorizationRoleStorageService)
        {
            _logger = logger;
            _mapper = mapper;
            _authorizationRoleStorageService = authorizationRoleStorageService;
        }

        public async Task AddAuthorizationRoleAsync(AddAuthorizationRoleRequest request, CancellationToken cancellationToken)
        {
            await _authorizationRoleStorageService.AddAsync(new AuthorizationRoleRecord
            {
                Id = request.Id,
                Name = request.Name,
                Actions = request.Actions
            }, cancellationToken);
        }

        public async Task<GetAllAuthorizationRolesResponse> GetAllAuthorizationRolesAsync(CancellationToken cancellationToken)
        {
            var result = await _authorizationRoleStorageService.GetAllAsync(cancellationToken);

            var response = _mapper.Map<GetAllAuthorizationRolesResponse>(result);

            return response;
        }
    }
}
