using PetsOnTrail.Actions.Options;
using PetsOnTrail.Interfaces.Actions.Services;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace PetsOnTrail.Actions.Services.PetsManage;

internal static class DiComposerPets
{
    public static IServiceCollection AddPets(this IServiceCollection services, TypeAdapterConfig typeAdapterConfig, PetsOnTrailOptions options)
    {
        typeAdapterConfig.AddPetsMapping();
            
        services.AddScoped<IPetsService, PetsService>();

        return services;
    }
}