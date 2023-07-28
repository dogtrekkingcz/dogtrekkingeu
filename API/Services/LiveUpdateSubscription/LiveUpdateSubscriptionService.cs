using System.Collections.ObjectModel;
using DogsOnTrail.Interfaces.Actions.Entities.LiveUpdateSubscription;
using DogsOnTrail.Interfaces.Actions.Services;

namespace DogsOnTrail.Actions.Services.LiveUpdateSubscription;

public class LiveUpdateSubscriptionService : ILiveUpdateSubscriptionService
{
    public IDictionary<string, List<LiveUpdateSubscriptionItem>> Repository { get; set; } = new Dictionary<string, List<LiveUpdateSubscriptionItem>>();
    
    public async Task AddAsync(AddLiveUpdateSubscriptionRequest request, CancellationToken cancellationToken)
    {
        
    }

    public async Task UserCancelledSubscriptionAsync(CancelLiveUpdateSubscriptionRequest request, CancellationToken cancellationToken)
    {
        
    }

    public async Task AddLiveUpdateSubscriptionAsync(AddLiveUpdateSubscriptionRequest request, CancellationToken cancellationToken)
    {
        Repository[request.Peer] = new List<LiveUpdateSubscriptionItem>();
        
        Repository[request.Peer].Add(new LiveUpdateSubscriptionItem
        {
            From = "Server",
            ServerTime = DateTimeOffset.Now,
            Type = LiveUpdateSubscriptionItem.TypeOfMessage.Info,
            Message = "Welcome to the live  updating of the server state"
        });
    }
}