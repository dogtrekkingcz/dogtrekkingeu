using DogsOnTrail.Actions.Services.ActionsManage;
using DogsOnTrail.Actions.Services.EntriesManage;
using DogsOnTrail.Actions.Services.ResultsManage;
using DogsOnTrail.Actions.Services.Rights;
using SharedCode.Options;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace DogsOnTrail.Actions
{
    public static class DIComposer
    {
        public static IServiceCollection AddBaseLayer(this IServiceCollection services, TypeAdapterConfig typeAdapterConfig, DogsOnTrailOptions options)
        {
            services
                .AddActions(typeAdapterConfig, options)
                .AddEntries(typeAdapterConfig, options)
                .AddRights(typeAdapterConfig)
                .AddUserProfiles(typeAdapterConfig, options)
                .AddDogs(typeAdapterConfig, options)
                .AddResults(typeAdapterConfig, options);
            
            return services;
        }
    }
}
