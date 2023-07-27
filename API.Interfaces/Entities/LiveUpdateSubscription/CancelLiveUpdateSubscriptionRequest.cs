namespace DogsOnTrail.Interfaces.Actions.Entities.LiveUpdateSubscription;

public sealed record CancelLiveUpdateSubscriptionRequest
{
    public string Peer { get; set; }
}