using DogtrekkingCz.Interfaces.Actions.Services;
using DogtrekkingCzShared.Options;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace DogtrekkingCz.Actions.Services.EntriesManage;

internal static class DiComposerEntries
{
    public static IServiceCollection AddEntries(this IServiceCollection services, TypeAdapterConfig typeAdapterConfig, DogtrekkingCzOptions options)
    {
        typeAdapterConfig.AddEntriesMapping();
            
        services.AddScoped<IEntriesService, EntriesService>();

        return services;
    }
}