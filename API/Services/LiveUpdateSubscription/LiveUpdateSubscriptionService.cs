using System.Collections.ObjectModel;
using PetsOnTrail.Interfaces.Actions.Entities.LiveUpdateSubscription;
using PetsOnTrail.Interfaces.Actions.Services;
using Microsoft.Extensions.DependencyInjection;

namespace PetsOnTrail.Actions.Services.LiveUpdateSubscription;

public class LiveUpdateSubscriptionService : ILiveUpdateSubscriptionService
{
    public IDictionary<string, LiveUpdateSubscriptionData> Repository { get; set; } = new Dictionary<string, LiveUpdateSubscriptionData>();

    private readonly IServiceProvider _serviceProvider;
    
    public LiveUpdateSubscriptionService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    
    public async Task SendAsync(SendLiveUpdateRequest request, CancellationToken cancellationToken)
    {
        var targetedPeers = new List<string>();
        
        if (string.IsNullOrWhiteSpace(request.ToSection) == false)
        {
            targetedPeers.AddRange(Repository
                .Where(rep => rep.Value.Settings.Section == request.ToSection)
                .Select(rep => rep.Key)
                .ToList());
        }

        if (string.IsNullOrWhiteSpace(request.ToUser) == false)
        {
            targetedPeers.AddRange(Repository
                .Where(rep => rep.Value.Settings.User == request.ToUser)
                .Select(rep => rep.Key)
                .ToList());
        }
        
        targetedPeers.ForEach(peer => 
            Repository[peer].Items.Add(new LiveUpdateSubscriptionData.LiveUpdateSubscriptionItemDto
            {
                From = "Server",
                ServerTime = DateTimeOffset.Now,
                Section = request.FromSection,
                User = request.FromUser,
                Type = LiveUpdateSubscriptionData.TypeOfMessage.Info,
                Message = request.Message
            }));
    }

    public async Task UserCancelledSubscriptionAsync(CancelLiveUpdateSubscriptionRequest request, CancellationToken cancellationToken)
    {
        
    }

    public async Task AddLiveUpdateSubscriptionAsync(AddLiveUpdateSubscriptionRequest request, CancellationToken cancellationToken)
    {
        var currentUserIdService = _serviceProvider.CreateScope().ServiceProvider.GetRequiredService<ICurrentUserIdService>();
        
        Repository[request.Peer] = new LiveUpdateSubscriptionData
        {
            Settings = new LiveUpdateSubscriptionData.LiveUpdateSubscriptionSettingsDto
            {
                Section = request.Section,
                User = currentUserIdService.GetUserId(),
                Subscribed = DateTimeOffset.Now
            },
            Items = new List<LiveUpdateSubscriptionData.LiveUpdateSubscriptionItemDto>()
        };
        
        Repository[request.Peer].Items.Add(new LiveUpdateSubscriptionData.LiveUpdateSubscriptionItemDto
        {
            From = "Server",
            ServerTime = DateTimeOffset.Now,
            Section = request.Section,
            User = currentUserIdService.GetUserId(),
            Type = LiveUpdateSubscriptionData.TypeOfMessage.Info,
            Message = "Welcome to the live  updating of the server state"
        });
    }
}