using DogsOnTrail.Actions.Options;
using DogsOnTrail.Interfaces.Actions.Services;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace DogsOnTrail.Actions.Services.ResultsManage;

internal static class DiComposerResults
{
    public static IServiceCollection AddResults(this IServiceCollection services, TypeAdapterConfig typeAdapterConfig, DogsOnTrailOptions options)
    {
        typeAdapterConfig.AddResultsMapping();
            
        services.AddScoped<IResultsService, ResultsService>();

        return services;
    }
}