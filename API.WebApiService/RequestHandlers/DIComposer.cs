using System.Runtime.CompilerServices;
using SharedCode.Entities;
using DogsOnTrailWebApiService.Entities;
using DogsOnTrailWebApiService.RequestHandlers.Actions;
using DogsOnTrailWebApiService.RequestHandlers.Entries;
using Google.Protobuf.Collections;
using Mapster;
using Mediator;

namespace DogsOnTrailWebApiService.RequestHandlers
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
