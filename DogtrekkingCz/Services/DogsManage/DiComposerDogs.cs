using DogtrekkingCz.Actions.Services.DogsManage;
using DogtrekkingCz.Interfaces.Actions.Services;
using DogtrekkingCzShared.Options;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace DogtrekkingCz.Actions.Services.EntriesManage;

internal static class DiComposerDogs
{
    public static IServiceCollection AddDogs(this IServiceCollection services, TypeAdapterConfig typeAdapterConfig, DogtrekkingCzOptions options)
    {
        typeAdapterConfig.AddDogsMapping();
            
        services.AddScoped<IDogsService, DogsService>();

        return services;
    }
}