using DogtrekkingCz.Interfaces.Actions.Services;
using DogtrekkingCzShared.Options;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace DogtrekkingCz.Actions.Services.Actions;

internal static class DiComposerActions
{
    public static IServiceCollection AddActions(this IServiceCollection services, TypeAdapterConfig typeAdapterConfig, DogtrekkingCzOptions options)
    {
        typeAdapterConfig.AddActionsMapping();
        
        services.AddScoped<IActionsService, ActionsService>();
        
        return services;
    }
}