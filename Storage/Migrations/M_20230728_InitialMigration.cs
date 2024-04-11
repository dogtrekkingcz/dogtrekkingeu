using Storage.Entities.ActionRights;
using Storage.Entities.AuthorizationRoles;
using Storage.Entities.UserProfiles;
using Storage.Migrations._2024;

namespace Storage.Migrations;

internal class M_20230728_InitialMigration : M_00_MigrationBase
{
    protected override Guid Id { get; init; } = Guid.Parse("6362aefb-e6fc-4bd1-a534-26c5b7333cff");
    protected override string Name { get; init; } = nameof(M_20230728_InitialMigration);

    public M_20230728_InitialMigration(IServiceProvider serviceProvider) : base(serviceProvider) 
    {
        this
            .AddUpAction(AuthorizationRolesRepositoryService.AddAuthorizationRoleAsync(new AddAuthorizationRoleRequest
            {
                Id = Constants.Roles.InternalAdministrator.Id,
                Name = Constants.Roles.InternalAdministrator.Name,
                Actions = Constants.Roles.InternalAdministrator.Actions
            }, CancellationToken.None))

            .AddUpAction(UserProfilesRepositoryService.AddUserProfileAsync(new CreateUserProfileInternalStorageRequest
            {
                Id = "admin@petsontrail.eu",
                UserId = "aaa"
            }, CancellationToken.None));

            //.AddUpAction(ActionRightsRepositoryService.AddActionRightsAsync(new AddActionRightsInternalStorageRequest
            //{
            //    Id = Guid.NewGuid().ToString(),
            //    UserId = "aaa",
            //    Roles = new List<string>
            //    {
            //        Constants.Roles.InternalAdministrator.Id
            //    },
            //    ActionId = string.Empty
            //}, CancellationToken.None))

            //.AddDownAction(ActionRightsRepositoryService.DeleteActionRightsAsync("aaa", CancellationToken.None));
    }
}