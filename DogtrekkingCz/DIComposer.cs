using DogtrekkingCz.Actions.Services.ActionsManage;
using DogtrekkingCz.Actions.Services.EntriesManage;
using DogtrekkingCz.Actions.Services.Rights;
using DogtrekkingCzShared.Options;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace DogtrekkingCz.Actions
{
    public static class DIComposer
    {
        public static IServiceCollection AddBaseLayer(this IServiceCollection services, TypeAdapterConfig typeAdapterConfig, DogtrekkingCzOptions options)
        {
            services
                .AddActions(typeAdapterConfig, options)
                .AddEntries(typeAdapterConfig, options)
                .AddRights(typeAdapterConfig)
                .AddUserProfiles(typeAdapterConfig, options);
            
            return services;
        }
    }
}
