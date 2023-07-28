using Storage.Interfaces;

namespace Storage.Migrations;

internal abstract class M_00_MigrationBase : IMigration
{
    protected readonly IActionRightsRepositoryService ActionRightsRepositoryService;
    protected readonly IActionsRepositoryService ActionsRepositoryService;
    protected readonly IAuthorizationRolesRepositoryService AuthorizationRolesRepositoryService;
    protected readonly IDogsRepositoryService DogsRepositoryService;
    protected readonly IEntriesRepositoryService EntriesRepositoryService;
    protected readonly IUserProfilesRepositoryService UserProfilesRepositoryService;

    public M_00_MigrationBase()
    {
        
    }
    
    public M_00_MigrationBase(
        IActionRightsRepositoryService actionRightsRepositoryService,
        IActionsRepositoryService actionsRepositoryService,
        IAuthorizationRolesRepositoryService authorizationRolesRepositoryService,
        IDogsRepositoryService dogsRepositoryService,
        IEntriesRepositoryService entriesRepositoryService,
        IUserProfilesRepositoryService userProfilesRepositoryService
        )
    {
        ActionRightsRepositoryService = actionRightsRepositoryService;
        ActionsRepositoryService = actionsRepositoryService;
        AuthorizationRolesRepositoryService = authorizationRolesRepositoryService;
        DogsRepositoryService = dogsRepositoryService;
        EntriesRepositoryService = entriesRepositoryService;
        UserProfilesRepositoryService = userProfilesRepositoryService;
    }

    public abstract Task RunAsync(CancellationToken cancellationToken);
}