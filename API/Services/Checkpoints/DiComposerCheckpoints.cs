using PetsOnTrail.Actions.Options;
using PetsOnTrail.Interfaces.Actions.Services;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace PetsOnTrail.Actions.Services.Checkpoints;

internal static class DiComposerCheckpoints
{
    public static IServiceCollection AddCheckpoints(this IServiceCollection services, TypeAdapterConfig typeAdapterConfig, PetsOnTrailOptions options)
    {
        typeAdapterConfig.AddCheckpointsMapping();
            
        services.AddScoped<ICheckpointsService, CheckpointsService>();

        return services;
    }
}