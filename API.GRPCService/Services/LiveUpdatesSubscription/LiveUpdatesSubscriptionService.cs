namespace API.GRPCService.Services.LiveUpdatesSubscription;

public class LiveUpdatesSubscriptionService : Protos.LiveUpdatesSubscription.LiveUpdatesSubscription.LiveUpdatesSubscriptionBase
{
    public async override Task<Protos.LiveUpdatesSubscription.LiveUpdateSubscriptionResponse> addResult(Protos.LiveUpdatesSubscription.LiveUpdateSubscriptionRequest request, ServerCallContext context)
    {
        return new LiveUpdateSubscriptionResponse
        {
            

        };
    }
}