using DogsOnTrail.Interfaces.Actions.Entities.LiveUpdateSubscription;
using DogsOnTrail.Interfaces.Actions.Entities.Results;
using Mapster;

namespace API.GRPCService.Services.LiveUpdatesSubscription;

internal static class LiveUpdatesSubscriptionServiceMapping
{
    internal static TypeAdapterConfig AddLiveUpdatesSubscriptionMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<LiveUpdateSubscriptionItem, Protos.LiveUpdatesSubscription.LiveUpdatesSubscriptionItem>();
        typeAdapterConfig.NewConfig<LiveUpdateSubscriptionItem.TypeOfMessage, Protos.LiveUpdatesSubscription.TypeOfMessage>();
        
        typeAdapterConfig.NewConfig<Protos.LiveUpdatesSubscription.LiveUpdatesSubscriptionRequest, AddLiveUpdateSubscriptionRequest>();
        
        typeAdapterConfig.NewConfig<Protos.LiveUpdatesSubscription.LiveUpdatesSubscriptionRequest, AddLiveUpdateSubscriptionRequest>()
            .Ignore(d => d.Peer);

        return typeAdapterConfig;
    }
}