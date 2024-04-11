using Microsoft.Extensions.Hosting;
using Storage.Migrations;

namespace Storage.Services;

internal class MigrationsService : IMigrationsService
{
    public async Task RunMigrationsAsync(IHost host, CancellationToken cancellationToken)
    {
        try 
        { 
            await new M_20230728_InitialMigration(host.Services).UpAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[FAILED] Load initial migration: '{ex.Message}'");
        }


        try
        {
            await new M_20240410_LoadActionsForYear2024(host.Services).UpAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[FAILED] Load actions for 2024: '{ex.Message}'");
        }
    }
}