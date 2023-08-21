using DogsOnTrail.Actions.Options;
using DogsOnTrail.Actions.Services.Checkpoints;
using DogsOnTrail.Interfaces.Actions.Services;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace DogsOnTrail.Actions.Services.Activities;

internal static class DiComposerActivities
{
    public static IServiceCollection AddActivities(this IServiceCollection services, TypeAdapterConfig typeAdapterConfig, DogsOnTrailOptions options)
    {
        typeAdapterConfig.AddActivitiesMapping();
            
        services.AddScoped<IActivitiesService, ActivitiesService>();

        return services;
    }
}