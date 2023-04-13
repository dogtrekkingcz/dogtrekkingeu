using System.Runtime.CompilerServices;
using DogtrekkingCzShared.Entities;
using DogtrekkingCzWebApiService.Entities;
using DogtrekkingCzWebApiService.RequestHandlers.Actions;
using DogtrekkingCzWebApiService.RequestHandlers.Entries;
using Google.Protobuf.Collections;
using Mapster;
using Mediator;

namespace DogtrekkingCzWebApiService.RequestHandlers
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
