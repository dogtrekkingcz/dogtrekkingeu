using PetsOnTrail.Actions.Options;
using PetsOnTrail.Actions.Services.Checkpoints;
using PetsOnTrail.Interfaces.Actions.Services;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace PetsOnTrail.Actions.Services.Activities;

internal static class DiComposerActivities
{
    public static IServiceCollection AddActivities(this IServiceCollection services, TypeAdapterConfig typeAdapterConfig, PetsOnTrailOptions options)
    {
        typeAdapterConfig.AddActivitiesMapping();
            
        services.AddScoped<IActivitiesService, ActivitiesService>();

        return services;
    }
}