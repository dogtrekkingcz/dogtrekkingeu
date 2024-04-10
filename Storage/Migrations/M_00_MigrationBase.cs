using Storage.Interfaces;

namespace Storage.Migrations;

internal abstract class M_00_MigrationBase : IMigration
{
    protected readonly IActionRightsRepositoryService ActionRightsRepositoryService;
    protected readonly IActionsRepositoryService ActionsRepositoryService;
    protected readonly IAuthorizationRolesRepositoryService AuthorizationRolesRepositoryService;
    protected readonly IPetsRepositoryService DogsRepositoryService;
    protected readonly IEntriesRepositoryService EntriesRepositoryService;
    protected readonly IUserProfilesRepositoryService UserProfilesRepositoryService;
    protected readonly IMigrationsRepositoryService MigrationsRepositoryService;

    public M_00_MigrationBase()
    {
        
    }
    
    public M_00_MigrationBase(
        IActionRightsRepositoryService actionRightsRepositoryService,
        IActionsRepositoryService actionsRepositoryService,
        IAuthorizationRolesRepositoryService authorizationRolesRepositoryService,
        IPetsRepositoryService petsRepositoryService,
        IEntriesRepositoryService entriesRepositoryService,
        IUserProfilesRepositoryService userProfilesRepositoryService,
        IMigrationsRepositoryService migrationsRepositoryService
        )
    {
        ActionRightsRepositoryService = actionRightsRepositoryService;
        ActionsRepositoryService = actionsRepositoryService;
        AuthorizationRolesRepositoryService = authorizationRolesRepositoryService;
        DogsRepositoryService = petsRepositoryService;
        EntriesRepositoryService = entriesRepositoryService;
        UserProfilesRepositoryService = userProfilesRepositoryService;
        MigrationsRepositoryService = migrationsRepositoryService;
    }

    public abstract Task UpAsync(CancellationToken cancellationToken);

    public abstract Task DownAsync(CancellationToken cancellationToken);
}