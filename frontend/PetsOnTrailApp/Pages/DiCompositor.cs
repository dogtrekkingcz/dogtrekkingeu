using PetsOnTrailApp.Components.Results.Results;

namespace PetsOnTrailApp.Pages;

public static class DiCompositor
{
    public static IServiceCollection AddPages(this IServiceCollection services)
    {
        services
            .AddTransient<RacesViewBase>();

        return services;
    }
}
