﻿using System.Collections.Specialized;
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
    
    public override async Task<Protos.LiveUpdatesSubscription.LiveUpdatesSubscriptionItem> subscribeForUpdates(Protos.LiveUpdatesSubscription.LiveUpdatesSubscriptionRequest request, IServerStreamWriter<Protos.LiveUpdatesSubscription.LiveUpdatesSubscriptionItem> responseStream, ServerCallContext context)
    {
        var peer = context.Peer; // keep peer information because it is not available after disconnection
        context.CancellationToken.Register(() => _liveUpdateSubscriptionService.UserCancelledSubscriptionAsync(new CancelLiveUpdateSubscriptionRequest
        {
            Peer = context.Peer 
        }, context.CancellationToken));

        var addLiveUpdateSubscriptionRequest = _mapper.Map<AddLiveUpdateSubscriptionRequest>(request) with
        {
            Peer = context.Peer
        };
        await _liveUpdateSubscriptionService.AddLiveUpdateSubscriptionAsync(addLiveUpdateSubscriptionRequest, context.CancellationToken);
        await responseStream.WriteAsync(new Protos.LiveUpdatesSubscription.LiveUpdatesSubscriptionItem
        {
            Message = "welcome",
            ServerTime = DateTimeOffset.Now.ToGoogleDateTime(),
            Type = Protos.LiveUpdatesSubscription.TypeOfMessage.Info,
            From = "Server"
        }, context.CancellationToken);

        var expectedLifetime = (request.Created.ToDateTimeOffset() ?? DateTimeOffset.Now).AddMinutes(5);
        
        //  && expectedLifetime < DateTimeOffset.Now
        while (! context.CancellationToken.IsCancellationRequested)
        {
            await Task.Delay(2000); // Gotta look busy

            foreach (var item in _liveUpdateSubscriptionService.Repository[context.Peer])
            {
                await responseStream.WriteAsync(_mapper.Map<Protos.LiveUpdatesSubscription.LiveUpdatesSubscriptionItem>(item), context.CancellationToken);
            }

            await Task.Delay(2000);
            
            _liveUpdateSubscriptionService.Repository[context.Peer].Add(new LiveUpdateSubscriptionItem
            {
                From = "Server",
                Message = "test",
                ServerTime = DateTimeOffset.Now,
                Type = LiveUpdateSubscriptionItem.TypeOfMessage.Chat
            });
        }
        
        Console.WriteLine("Cancellation of the live update was requested");

        return new Protos.LiveUpdatesSubscription.LiveUpdatesSubscriptionItem
        {

        };
    }
}