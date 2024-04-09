using PetsOnTrail.Actions.Options;
using PetsOnTrail.Interfaces.Actions.Services;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace PetsOnTrail.Actions.Services.ActionsManage;

internal static class DiComposerActions
{
    public static IServiceCollection AddActions(this IServiceCollection services, TypeAdapterConfig typeAdapterConfig, PetsOnTrailOptions options)
    {
        typeAdapterConfig.AddActionsMapping();
        
        services.AddScoped<IActionsService, ActionsService>();
        
        return services;
    }
}