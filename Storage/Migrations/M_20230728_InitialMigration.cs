using Storage.Entities.ActionRights;
using Storage.Entities.AuthorizationRoles;
using Storage.Entities.UserProfiles;

namespace Storage.Migrations;

internal class M_20230728_InitialMigration : M_00_MigrationBase
{
    private readonly Guid _guid = Guid.Parse("6362aefb-e6fc-4bd1-a534-26c5b7333cff");

    public M_20230728_InitialMigration(IServiceProvider serviceProvider) : base(serviceProvider) { }

    public override async Task UpAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("M_20230728_InitialMigration UP is running");

        if (await MigrationsRepositoryService.GetAsync(_guid.ToString(), cancellationToken) is not null)
        {
            Console.WriteLine("M_20230728_InitialMigration UP is already done, the ID is exists");
            return;
        }

        await AuthorizationRolesRepositoryService.AddAuthorizationRoleAsync(new AddAuthorizationRoleRequest
        {
            Id = Constants.Roles.InternalAdministrator.Id,
            Name = Constants.Roles.InternalAdministrator.Name,
            Actions = Constants.Roles.InternalAdministrator.Actions
        }, cancellationToken);

        var userProfile = await UserProfilesRepositoryService.AddUserProfileAsync(new CreateUserProfileInternalStorageRequest
        {
            Id = "admin@petsontrail.eu",
            UserId = "aaa"
        }, cancellationToken);

        await ActionRightsRepositoryService.AddActionRightsAsync(new AddActionRightsInternalStorageRequest
        {
            Id = Guid.NewGuid().ToString(),
            UserId = userProfile.Id.ToString(),
            Roles = new List<string>
            {
                Constants.Roles.InternalAdministrator.Id
            },
            ActionId = string.Empty
        }, cancellationToken);

        await MigrationsRepositoryService.CreateMigrationAsync(new Entities.Migrations.CreateMigrationInternalStorageRequest
        {
            Id = _guid.ToString(),
            Name = nameof(M_20230728_InitialMigration),
            Created = DateTime.UtcNow
        }, cancellationToken);

        Console.WriteLine("M_20230728_InitialMigration UP is done");
    }

    public override async Task DownAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("M_20230728_InitialMigration DOWN is running");

        if (await MigrationsRepositoryService.GetAsync(_guid.ToString(), cancellationToken) is null)
        {
            Console.WriteLine("M_20230728_InitialMigration DOWN is already done, the ID is not exists");
            return;
        }

        // await AuthorizationRolesRepositoryService.DeleteAuthorizationRoleAsync(Constants.Roles.InternalAdministrator.Id, cancellationToken);
        // await UserProfilesRepositoryService.DeleteUserProfileAsync("")

        await MigrationsRepositoryService.DeleteMigrationAsync(_guid.ToString(), cancellationToken);

        Console.WriteLine("M_20230728_InitialMigration DOWN is done");
    }
}