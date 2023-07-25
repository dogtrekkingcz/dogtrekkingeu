using DogsOnTrail.Actions.Options;
using DogsOnTrail.Interfaces.Actions.Services;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace DogsOnTrail.Actions.Services.EntriesManage;

internal static class DiComposerEntries
{
    public static IServiceCollection AddEntries(this IServiceCollection services, TypeAdapterConfig typeAdapterConfig, DogsOnTrailOptions options)
    {
        typeAdapterConfig.AddEntriesMapping();
            
        services.AddScoped<IEntriesService, EntriesService>();

        return services;
    }
}