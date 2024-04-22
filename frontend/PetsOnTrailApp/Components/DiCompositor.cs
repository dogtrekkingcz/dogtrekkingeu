using Mapster;
using PetsOnTrailApp.Components.ActionView;
using PetsOnTrailApp.Components.Loading;
using PetsOnTrailApp.Components.Results.CategoriesView;
using PetsOnTrailApp.Components.Results.CategoryView;
using PetsOnTrailApp.Components.Results.RacesView;
using PetsOnTrailApp.Components.Results.ResultsAdd;

namespace PetsOnTrailApp.Components;

internal static class DiCompositor
{
    internal static IServiceCollection AddComponents(this IServiceCollection services)
    {
        services
            .AddTransient<ResultsAddBase>()
            .AddTransient<LoadingBase>()
            .AddTransient<CategoriesViewBase>()
            .AddTransient<RacesViewBase>()
            .AddTransient<CategoryViewBase>()
            .AddTransient<ActionViewBase>();

        return services;
    }

    internal static TypeAdapterConfig AddComponentMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        //typeAdapterConfig
        //    .AddResultsAddMapping();

        return typeAdapterConfig;
    }
}
