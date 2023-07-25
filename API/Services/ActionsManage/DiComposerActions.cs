using DogsOnTrail.Actions.Options;
using DogsOnTrail.Interfaces.Actions.Services;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace DogsOnTrail.Actions.Services.ActionsManage;

internal static class DiComposerActions
{
    public static IServiceCollection AddActions(this IServiceCollection services, TypeAdapterConfig typeAdapterConfig, DogsOnTrailOptions options)
    {
        typeAdapterConfig.AddActionsMapping();
        
        services.AddScoped<IActionsService, ActionsService>();
        
        return services;
    }
}