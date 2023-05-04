using DogtrekkingCz.Interfaces.Actions.Services;
using DogtrekkingCzShared.Options;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace DogtrekkingCz.Actions.Services.ResultsManage;

internal static class DiComposerResults
{
    public static IServiceCollection AddResults(this IServiceCollection services, TypeAdapterConfig typeAdapterConfig, DogtrekkingCzOptions options)
    {
        typeAdapterConfig.AddResultsMapping();
            
        services.AddScoped<IResultsService, ResultsService>();

        return services;
    }
}