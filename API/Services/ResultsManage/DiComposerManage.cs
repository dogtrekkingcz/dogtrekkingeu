using PetsOnTrail.Actions.Options;
using PetsOnTrail.Interfaces.Actions.Services;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace PetsOnTrail.Actions.Services.ResultsManage;

internal static class DiComposerResults
{
    public static IServiceCollection AddResults(this IServiceCollection services, TypeAdapterConfig typeAdapterConfig, PetsOnTrailOptions options)
    {
        typeAdapterConfig.AddResultsMapping();
            
        services.AddScoped<IResultsService, ResultsService>();

        return services;
    }
}