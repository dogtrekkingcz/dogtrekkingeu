using PetsOnTrail.Actions.Options;
using PetsOnTrail.Interfaces.Actions.Services;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace PetsOnTrail.Actions.Services.EntriesManage;

internal static class DiComposerEntries
{
    public static IServiceCollection AddEntries(this IServiceCollection services, TypeAdapterConfig typeAdapterConfig, PetsOnTrailOptions options)
    {
        typeAdapterConfig.AddEntriesMapping();
            
        services.AddScoped<IEntriesService, EntriesService>();

        return services;
    }
}