using DogsOnTrail.Actions.Options;
using DogsOnTrail.Interfaces.Actions.Services;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace DogsOnTrail.Actions.Services.PetsManage;

internal static class DiComposerPets
{
    public static IServiceCollection AddPets(this IServiceCollection services, TypeAdapterConfig typeAdapterConfig, DogsOnTrailOptions options)
    {
        typeAdapterConfig.AddPetsMapping();
            
        services.AddScoped<IPetsService, PetsService>();

        return services;
    }
}