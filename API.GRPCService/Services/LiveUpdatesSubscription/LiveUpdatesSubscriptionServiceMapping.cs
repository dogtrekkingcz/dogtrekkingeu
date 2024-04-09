using PetsOnTrail.Interfaces.Actions.Entities.LiveUpdateSubscription;
using PetsOnTrail.Interfaces.Actions.Entities.Results;
using Mapster;

namespace API.GRPCService.Services.LiveUpdatesSubscription;

internal static class LiveUpdatesSubscriptionServiceMapping
{
    internal static TypeAdapterConfig AddLiveUpdatesSubscriptionMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<LiveUpdateSubscriptionData.LiveUpdateSubscriptionItemDto, Protos.LiveUpdatesSubscription.LiveUpdatesSubscriptionItem>();
        typeAdapterConfig.NewConfig<LiveUpdateSubscriptionData.TypeOfMessage, Protos.LiveUpdatesSubscription.TypeOfMessage>();
        
        typeAdapterConfig.NewConfig<Protos.LiveUpdatesSubscription.LiveUpdatesSubscriptionRequest, AddLiveUpdateSubscriptionRequest>();
        
        typeAdapterConfig.NewConfig<Protos.LiveUpdatesSubscription.LiveUpdatesSubscriptionRequest, AddLiveUpdateSubscriptionRequest>()
            .Ignore(d => d.Peer);

        return typeAdapterConfig;
    }
}