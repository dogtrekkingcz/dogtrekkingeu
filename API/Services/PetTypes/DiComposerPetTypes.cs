using PetsOnTrail.Actions.Options;
using PetsOnTrail.Interfaces.Actions.Services;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace PetsOnTrail.Actions.Services.PetsManage;

internal static class DiComposerPetTypes
{
    public static IServiceCollection AddPetTypes(this IServiceCollection services, TypeAdapterConfig typeAdapterConfig, PetsOnTrailOptions options)
    {
        typeAdapterConfig.AddPetTypesMapping();
            
        services.AddScoped<IPetTypesService, PetTypesService>();

        return services;
    }
}