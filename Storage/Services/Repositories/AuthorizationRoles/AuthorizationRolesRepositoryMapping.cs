using Mapster;

namespace Storage.Services.Repositories.Migrations
{
    internal static class AuthorizationRolesRepositoryMapping
    {
        internal static TypeAdapterConfig AddAuthorizationRolesRepositoryMapping(this TypeAdapterConfig typeAdapterConfig)
        {

            typeAdapterConfig.NewConfig<Entities.AuthorizationRoles.AddAuthorizationRoleRequest, Models.AuthorizationRoleRecord>()
                .Ignore(d => d.CorrelationId);
            typeAdapterConfig.NewConfig<Entities.AuthorizationRoles.AddAuthorizationRoleRequest.RoleType, Models.AuthorizationRoleRecord.RoleType>();

            typeAdapterConfig.NewConfig<Models.AuthorizationRoleRecord, Entities.AuthorizationRoles.GetAllAuthorizationRolesResponse.AuthorizationRoleDto>();
            typeAdapterConfig.NewConfig<Models.AuthorizationRoleRecord.RoleType, Entities.AuthorizationRoles.GetAllAuthorizationRolesResponse.RoleType>();

            return typeAdapterConfig;
        }
    }
}