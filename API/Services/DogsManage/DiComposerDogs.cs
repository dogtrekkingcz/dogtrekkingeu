using DogsOnTrail.Actions.Services.DogsManage;
using DogsOnTrail.Interfaces.Actions.Services;
using SharedCode.Options;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace DogsOnTrail.Actions.Services.EntriesManage;

internal static class DiComposerDogs
{
    public static IServiceCollection AddDogs(this IServiceCollection services, TypeAdapterConfig typeAdapterConfig, DogsOnTrailOptions options)
    {
        typeAdapterConfig.AddDogsMapping();
            
        services.AddScoped<IDogsService, DogsService>();

        return services;
    }
}