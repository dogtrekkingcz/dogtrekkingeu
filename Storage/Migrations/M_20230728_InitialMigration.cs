using Storage.Entities.ActionRights;
using Storage.Entities.AuthorizationRoles;
using Storage.Entities.UserProfiles;
using Storage.Migrations._2024;

namespace Storage.Migrations;

internal class M_20230728_InitialMigration : M_00_MigrationBase
{
    protected override Guid Id { get; init; } = Guid.Parse("6362aefb-e6fc-4bd1-a534-26c5b7333cff");
    protected override string Name { get; init; } = nameof(M_20230728_InitialMigration);


    private string _userIdAdmin = "29bf10f1-8f4a-43f3-8e1b-448d0fbf7bef";
    private string _userIdRadekKotesovec = "f6191db1-d1ba-4714-9ddc-09a3325762e3";

    public M_20230728_InitialMigration(IServiceProvider serviceProvider) : base(serviceProvider) 
    {
        this
            .AddUpAction(AuthorizationRolesRepositoryService.AddAuthorizationRoleAsync(new AddAuthorizationRoleRequest
            {
                Id = Constants.Roles.InternalAdministrator.Id,
                Name = Constants.Roles.InternalAdministrator.Name,
                Actions = new List<Constants.ActionType>
                {
                    Constants.ActionType.GlobalRead,
                    Constants.ActionType.GlobalInsert,
                    Constants.ActionType.GlobalUpdate,
                    Constants.ActionType.GlobalDelete
                }
            }, CancellationToken.None))

            .AddUpAction(AuthorizationRolesRepositoryService.AddAuthorizationRoleAsync(new AddAuthorizationRoleRequest
            {
                Id = Constants.Roles.InternalUser.Id,
                Name = Constants.Roles.InternalUser.Name,
                Actions = new List<Constants.ActionType>
                {
                    Constants.ActionType.ActionsRead,
                    Constants.ActionType.ActionsInsert,
                    Constants.ActionType.ActionsUpdateOwn,
                    Constants.ActionType.ActionsDeleteOwn
                }
            }, CancellationToken.None))

            .AddUpAction(AuthorizationRolesRepositoryService.AddAuthorizationRoleAsync(new AddAuthorizationRoleRequest
            {
                Id = Constants.Roles.ExternalUser.Id,
                Name = Constants.Roles.ExternalUser.Name,
                Actions = new List<Constants.ActionType>
                {
                    Constants.ActionType.ActionsRead
                }
            }, CancellationToken.None))

            //------------------------------------------------------------------------------------------------------------

            .AddUpAction(UserProfilesRepositoryService.AddUserProfileAsync(new CreateUserProfileInternalStorageRequest
            {
                Id = _userIdAdmin,
                FirstName = "Admin",
                LastName = "Admin",
                Contact = new CreateUserProfileInternalStorageRequest.ContactDto
                {
                    EmailAddress = "admin@petsontrail.eu",
                    PhoneNumber = "+420 728 245 996"
                },
                UserId = "admin@petsontrail.eu",
                Roles = new List<string>
                {
                    Constants.Roles.InternalAdministrator.Id
                }
            }, CancellationToken.None))

            .AddUpAction(UserProfilesRepositoryService.AddUserProfileAsync(new CreateUserProfileInternalStorageRequest
            {
                Id = _userIdRadekKotesovec,
                FirstName = "Radek",
                LastName = "Kotěšovec",
                Contact = new CreateUserProfileInternalStorageRequest.ContactDto
                {
                    EmailAddress = "radek.kotesovec@dogtrekking.cz",
                    PhoneNumber = "+420 728 245 996"
                },
                UserId = "radek.kotesovec@dogtrekking.cz",
                Roles = new List<string>
                {
                    Constants.Roles.InternalAdministrator.Id
                }
            }, CancellationToken.None))

            // ------------------------------------------------------------------------------------------------------------

            .AddDownAction(UserProfilesRepositoryService.DeleteUserProfileAsync(new DeleteUserProfileInternalStorageRequest { Id = _userIdRadekKotesovec }, CancellationToken.None))
            .AddDownAction(UserProfilesRepositoryService.DeleteUserProfileAsync(new DeleteUserProfileInternalStorageRequest { Id = _userIdAdmin }, CancellationToken.None))
            .AddDownAction(AuthorizationRolesRepositoryService.DeleteAuthorizationRoleAsync(Constants.Roles.InternalAdministrator.Id.ToString(), CancellationToken.None))
            .AddDownAction(AuthorizationRolesRepositoryService.DeleteAuthorizationRoleAsync(Constants.Roles.InternalUser.Id.ToString(), CancellationToken.None))
            .AddDownAction(AuthorizationRolesRepositoryService.DeleteAuthorizationRoleAsync(Constants.Roles.ExternalUser.Id.ToString(), CancellationToken.None));
    }
}