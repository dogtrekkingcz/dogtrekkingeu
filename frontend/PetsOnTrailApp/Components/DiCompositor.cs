using Mapster;
using PetsOnTrailApp.Components.ResultsAdd;

namespace PetsOnTrailApp.Components;

internal static class DiCompositor
{
    internal static IServiceCollection AddComponents(this IServiceCollection services)
    {
        services
            .AddTransient<ResultsAddBase>();

        return services;
    }

    internal static TypeAdapterConfig AddComponentMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig
            .AddResultsAddMapping();

        return typeAdapterConfig;
    }
}
