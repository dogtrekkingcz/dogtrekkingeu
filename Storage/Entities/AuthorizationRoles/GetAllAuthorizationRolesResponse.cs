using SharedCode.Entities;

namespace Storage.Entities.AuthorizationRoles
{
    public sealed record GetAllAuthorizationRolesResponse
    {
        public List<AuthorizationRoleDto> AuthorizationRoles { get; init; } = new List<AuthorizationRoleDto>();
    }
}
