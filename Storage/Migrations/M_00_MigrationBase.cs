using Microsoft.Extensions.DependencyInjection;
using Storage.Interfaces;
using System;

namespace Storage.Migrations;

internal abstract class M_00_MigrationBase : IMigration
{
    protected IServiceProvider ServiceProvider { get; }

    protected abstract Guid Id { get; init; }
    protected abstract string Name { get; init; }
    protected virtual List<Type> ActionsToMigrate { get; init; } = new();

    private List<Task> _upList = new();
    private List<Task> _downList = new();

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

    public M_00_MigrationBase AddUpAction(Task task)
    {
        _upList.Add(task);

        return this;
    }

    public M_00_MigrationBase AddDownAction(Task task)
    {
        _downList.Add(task);

        return this;
    }

    public async Task UpAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine($"[MIGRATION-UP] -> '{Name}' is running...");

        var migration = await MigrationsRepositoryService.GetAsync(Id.ToString(), cancellationToken);
        if (migration is not null)
        {
            Console.WriteLine($"[MIGRATION-UP] -> '{Name}' is already done, the ID is exists");
            return;
        }

        if (ActionsToMigrate.Count > 0)
            await Task.WhenAll(ActionsToMigrate.Select(action => (Activator.CreateInstance(action, ServiceProvider) as M_00_MigrationBase).UpAsync(cancellationToken)));
        else
            await Task.WhenAll(_upList.Select(action => action));


        await MigrationsRepositoryService.CreateMigrationAsync(new Entities.Migrations.CreateMigrationInternalStorageRequest
        {
            Id = Id.ToString(),
            Name = Name,
            Created = DateTime.UtcNow
        }, cancellationToken);

        Console.WriteLine($"[MIGRATION-UP] -> '{Name}' is finished");
    }

    public async Task DownAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine($"[MIGRATION-DOWN] -> '{Name}' is running...");

        if (await MigrationsRepositoryService.GetAsync(Id.ToString(), cancellationToken) is null)
        {
            Console.WriteLine($"[MIGRATION-DOWN] -> '{Name}' is already done, the ID is exists");
            return;
        }


        await Task.WhenAll(ActionsToMigrate.Select(action => (Activator.CreateInstance(action, ServiceProvider) as M_00_MigrationBase).DownAsync(cancellationToken)));


        await MigrationsRepositoryService.DeleteMigrationAsync(Id.ToString(), cancellationToken);

        Console.WriteLine($"[MIGRATION-DOWN] -> '{Name}' is finished");
    }
}