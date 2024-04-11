using Microsoft.Extensions.Hosting;

namespace Storage.Services;

internal interface IMigrationsService
{
    Task RunMigrationsAsync(IServiceProvider serviceProvider, CancellationToken cancellationToken);
}