using DogtrekkingCz.Interfaces.Rights.Services;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace DogtrekkingCz.Actions.Services.Rights;

internal static class DiComposerRights
{
    public static IServiceCollection AddRights(this IServiceCollection serviceCollection, TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.AddRightsMapping();

        serviceCollection.AddScoped<IRightsService, RightsService>();
        
        return serviceCollection;
    }
}