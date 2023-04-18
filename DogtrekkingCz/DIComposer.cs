using DogtrekkingCz.Actions.Services.Entries;
using DogtrekkingCz.Actions.Services.Rights;
using DogtrekkingCzShared.Options;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace DogtrekkingCz.Actions
{
    public static class DIComposer
    {
        public static IServiceCollection AddActions(this IServiceCollection services, TypeAdapterConfig typeAdapterConfig, DogtrekkingCzOptions options)
        {
            services
                .AddActions(typeAdapterConfig, options)
                .AddEntries(typeAdapterConfig, options)
                .AddRights(typeAdapterConfig);
            
            return services;
        }
    }
}
