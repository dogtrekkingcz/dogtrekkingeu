using Mapster;
using PetsOnTrailApp.Components.ActionsView;
using PetsOnTrailApp.Components.ActionView;
using PetsOnTrailApp.Components.ActionViewHeader;
using PetsOnTrailApp.Components.Loading;
using PetsOnTrailApp.Components.RaceView;
using PetsOnTrailApp.Components.Results.CategoriesView;
using PetsOnTrailApp.Components.Results.CategoryView;
using PetsOnTrailApp.Components.Results.RacesView;
using PetsOnTrailApp.Components.Results.ResultsAdd;
using PetsOnTrailApp.Components.UserActivitiesView;

namespace PetsOnTrailApp.Components;

internal static class DiCompositor
{
    internal static IServiceCollection AddComponents(this IServiceCollection services)
    {
        services
            .AddTransient<ActionViewHeaderBase>()
            .AddTransient<LoadingBase>()
            .AddTransient<ActionsViewBase>()
            .AddTransient<ActionViewBase>()
            .AddTransient<RacesViewBase>()
            .AddTransient<RaceViewBase>()
            .AddTransient<CategoriesViewBase>()
            .AddTransient<CategoryViewBase>()
            .AddTransient<ResultsAddBase>()
            .AddTransient<UserActivitiesViewBase>();

        return services;
    }

    internal static TypeAdapterConfig AddComponentMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        //typeAdapterConfig
        //    .AddResultsAddMapping();

        return typeAdapterConfig;
    }
}
