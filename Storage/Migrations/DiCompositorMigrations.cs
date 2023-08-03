using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace Storage.Migrations;

public static class DiCompositor
{
    public static IServiceCollection AddMigrations(this IServiceCollection serviceProvider, TypeAdapterConfig typeAdapterConfig)
    {
        ArgumentNullException.ThrowIfNull(serviceProvider);

        return serviceProvider;
    }   
}