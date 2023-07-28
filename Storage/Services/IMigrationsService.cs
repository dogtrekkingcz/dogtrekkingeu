using Microsoft.Extensions.Hosting;

namespace Storage.Services;

internal interface IMigrationsService
{
    Task RunMigrationsAsync(IHost host, CancellationToken cancellationToken);
}