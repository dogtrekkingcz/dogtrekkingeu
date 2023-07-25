using API.WebApiService.RequestHandlers.Actions;
using API.WebApiService.RequestHandlers.Entries;
using Mapster;

namespace API.WebApiService.RequestHandlers
{
    public static class DIComposerRequestHandlers
    {
        public static IServiceCollection AddRequestHandlers(this IServiceCollection services)
        {
            return services;
        }

        public static TypeAdapterConfig AddMapping(this TypeAdapterConfig typeAdapterConfig)
        {
            typeAdapterConfig
                .AddActionsMapping()
                .AddEntriesMapping();

            return typeAdapterConfig;
        }
    }
}
