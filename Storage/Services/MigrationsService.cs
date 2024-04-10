using Microsoft.Extensions.Hosting;
using Storage.Migrations;

namespace Storage.Services;

internal class MigrationsService : IMigrationsService
{
    public async Task RunMigrationsAsync(IHost host, CancellationToken cancellationToken)
    {
        await new M_20230728_InitialMigration(host.Services).UpAsync(cancellationToken);

        await new M_20240410_LoadActionsForYear2024(host.Services).UpAsync(cancellationToken);
    }
}