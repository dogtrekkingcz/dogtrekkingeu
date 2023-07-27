using System.Collections.ObjectModel;
using DogsOnTrail.Interfaces.Actions.Entities.LiveUpdateSubscription;
using DogsOnTrail.Interfaces.Actions.Services;

namespace DogsOnTrail.Actions.Services.LiveUpdateSubscription;

public class LiveUpdateSubscriptionService : ILiveUpdateSubscriptionService
{
    public IDictionary<string, ObservableCollection<LiveUpdateSubscriptionItem>> Repository { get; set; } = new Dictionary<string, ObservableCollection<LiveUpdateSubscriptionItem>>();
    
    public async Task AddAsync(AddLiveUpdateSubscriptionRequest request, CancellationToken cancellationToken)
    {
        
    }

    public async Task UserCancelledSubscriptionAsync(CancelLiveUpdateSubscriptionRequest request, CancellationToken cancellationToken)
    {
        
    }

    public async Task AddLiveUpdateSubscriptionAsync(AddLiveUpdateSubscriptionRequest request, CancellationToken cancellationToken)
    {
        Repository[request.Peer] = new ObservableCollection<LiveUpdateSubscriptionItem>();
        
        Repository[request.Peer].Add(new LiveUpdateSubscriptionItem
        {
            From = "Server",
            ServerTime = DateTimeOffset.Now,
            Type = LiveUpdateSubscriptionItem.TypeOfMessage.Info,
            Message = "Welcome"
        });
    }
}