using DogtrekkingCzShared.Entities;
using DogtrekkingCzWebApiService.Entities;
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

        internal static TypeAdapterConfig AddActionsMapping(this TypeAdapterConfig typeAdapterConfig)
        {
            typeAdapterConfig.NewConfig<ActionDetailRequest, DogtrekkingCz.Interfaces.Entities.ActionDetailRequest>();

            return typeAdapterConfig;
        }
    }
}
