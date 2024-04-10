using Microsoft.Extensions.DependencyInjection;
using Storage.Interfaces;

namespace Storage.Migrations;

internal abstract class M_00_MigrationBase : IMigration
{
    protected IServiceProvider ServiceProvider { get; }

    protected readonly IActionRightsRepositoryService ActionRightsRepositoryService;
    protected readonly IActionsRepositoryService ActionsRepositoryService;
    protected readonly IAuthorizationRolesRepositoryService AuthorizationRolesRepositoryService;
    protected readonly IPetsRepositoryService PetsRepositoryService;
    protected readonly IEntriesRepositoryService EntriesRepositoryService;
    protected readonly IUserProfilesRepositoryService UserProfilesRepositoryService;
    protected readonly IMigrationsRepositoryService MigrationsRepositoryService;

    public M_00_MigrationBase(IServiceProvider serviceProvider)
    {
        ServiceProvider = serviceProvider;

        ActionRightsRepositoryService = serviceProvider.GetRequiredService<IActionRightsRepositoryService>();
        ActionsRepositoryService = serviceProvider.GetRequiredService<IActionsRepositoryService>();
        AuthorizationRolesRepositoryService = serviceProvider.GetRequiredService<IAuthorizationRolesRepositoryService>();
        PetsRepositoryService = serviceProvider.GetRequiredService<IPetsRepositoryService>();
        EntriesRepositoryService = serviceProvider.GetRequiredService<IEntriesRepositoryService>();
        UserProfilesRepositoryService = serviceProvider.GetRequiredService<IUserProfilesRepositoryService>();
        MigrationsRepositoryService = serviceProvider.GetRequiredService<IMigrationsRepositoryService>();
    }

    public abstract Task UpAsync(CancellationToken cancellationToken);

    public abstract Task DownAsync(CancellationToken cancellationToken);
}