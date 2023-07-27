using System.Collections.Specialized;
using System.ComponentModel;
using API.GRPCService.Extensions;
using DogsOnTrail.Interfaces.Actions.Entities.LiveUpdateSubscription;
using DogsOnTrail.Interfaces.Actions.Services;
using Grpc.Core;
using MapsterMapper;
using Microsoft.VisualBasic;
using Protos.LiveUpdatesSubscription;

namespace API.GRPCService.Services.LiveUpdatesSubscription;

public class LiveUpdatesSubscriptionGrpcService : Protos.LiveUpdatesSubscription.LiveUpdatesSubscription.LiveUpdatesSubscriptionBase
{
    private readonly IMapper _mapper;
    private readonly ILiveUpdateSubscriptionService _liveUpdateSubscriptionService;
    
    public LiveUpdatesSubscriptionGrpcService(IMapper mapper, ILiveUpdateSubscriptionService liveUpdateSubscriptionService)
    {
        _mapper = mapper;
        _liveUpdateSubscriptionService = liveUpdateSubscriptionService;
    }
    
    public async override Task<Protos.LiveUpdatesSubscription.LiveUpdatesSubscriptionItem> subscribeForUpdates(Protos.LiveUpdatesSubscription.LiveUpdatesSubscriptionRequest request, IServerStreamWriter<Protos.LiveUpdatesSubscription.LiveUpdatesSubscriptionItem> responseStream, ServerCallContext context)
    {
        var peer = context.Peer; // keep peer information because it is not available after disconnection
        context.CancellationToken.Register(() => _liveUpdateSubscriptionService.UserCancelledSubscriptionAsync(new CancelLiveUpdateSubscriptionRequest
        {
            Peer = context.Peer 
        }, context.CancellationToken));

        await _liveUpdateSubscriptionService.AddLiveUpdateSubscriptionAsync(new AddLiveUpdateSubscriptionRequest
        {
            Peer = context.Peer,
            UserId = request.UserId,
            Created = request.Created.ToDateTimeOffset() ?? DateTimeOffset.Now,
            Section = request.Section,
            AdditionalInfo = request.AdditionalInfo
        }, context.CancellationToken);
        
        try
        {
            _liveUpdateSubscriptionService.Repository[""].CollectionChanged += (async (sender, args) =>
            {
                if(args.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (var newItem in args.NewItems ?? new Collection())
                    {
                        await responseStream.WriteAsync(_mapper.Map<Protos.LiveUpdatesSubscription.LiveUpdatesSubscriptionItem>(newItem), context.CancellationToken);
                    }
                }
            });
        }
        catch (TaskCanceledException)
        {
        }

        return new Protos.LiveUpdatesSubscription.LiveUpdatesSubscriptionItem
        {

        };
    }
}