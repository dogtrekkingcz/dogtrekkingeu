using DogsOnTrail.Actions.Options;
using DogsOnTrail.Interfaces.Actions.Services;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace DogsOnTrail.Actions.Services.Checkpoints;

internal static class DiComposerCheckpoints
{
    public static IServiceCollection AddCheckpoints(this IServiceCollection services, TypeAdapterConfig typeAdapterConfig, DogsOnTrailOptions options)
    {
        typeAdapterConfig.AddCheckpointsMapping();
            
        services.AddScoped<ICheckpointsService, CheckpointsService>();

        return services;
    }
}