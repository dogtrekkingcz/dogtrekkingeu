using Microsoft.Extensions.Hosting;
using Storage.Migrations;

namespace Storage.Services;

internal class MigrationsService : IMigrationsService
{
    public async Task RunMigrationsAsync(IServiceProvider serviceProvider, CancellationToken cancellationToken)
    {
        try 
        { 
            await new M_20230728_InitialMigration(serviceProvider).UpAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[FAILED] Load initial migration: '{ex}'");
        }


        try
        {
            await new M_20240410_LoadActionsForYear2024(serviceProvider).UpAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[FAILED] Load actions for 2024: '{ex}'");
        }
    }
}