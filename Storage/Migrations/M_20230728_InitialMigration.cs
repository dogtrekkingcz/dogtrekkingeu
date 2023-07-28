using Storage.Entities.ActionRights;
using Storage.Entities.AuthorizationRoles;
using Storage.Entities.UserProfiles;

namespace Storage.Migrations;

internal class M_20230728_InitialMigration : M_00_MigrationBase
{
    public override async Task RunAsync(CancellationToken cancellationToken)
    {
        await AuthorizationRolesRepositoryService.AddAuthorizationRoleAsync(new AddAuthorizationRoleRequest
        {
            Id = Constants.Roles.InternalAdministrator.Id,
            Name = Constants.Roles.InternalAdministrator.Name,
            Actions = Constants.Roles.InternalAdministrator.Actions
        }, cancellationToken);

        await UserProfilesRepositoryService.AddUserProfileAsync(new CreateUserProfileInternalStorageRequest
        {
            Id = "admin@petsontrail.eu",
            UserId = "aaa"
        }, cancellationToken);

        await ActionRightsRepositoryService.AddActionRightsAsync(new AddActionRightsInternalStorageRequest
        {
            Id = Guid.NewGuid().ToString(),
            UserId = "aaa",
            Roles = new List<string>
            {
                Constants.Roles.InternalAdministrator.Id
            },
            ActionId = string.Empty
        }, cancellationToken);
    }
}