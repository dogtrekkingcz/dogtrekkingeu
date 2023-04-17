using DogtrekkingCz.Interfaces.Actions.Entities;
using DogtrekkingCz.Interfaces.Actions.Services;
using DogtrekkingCzShared.Entities;
using DogtrekkingCzShared.Options;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
using Storage.Entities.Actions;


namespace DogtrekkingCz.Actions
{
    public static class DIComposer
    {
        public static IServiceCollection AddActions(this IServiceCollection services, TypeAdapterConfig typeAdapterConfig, DogtrekkingCzOptions options)
        {
            services.AddScoped<IActionsService, ActionsService>();
            
            typeAdapterConfig.NewConfig<GetAllActionsInternalStorageResponse, GetAllActionsResponse>();

            return services;
        }
    }
}
