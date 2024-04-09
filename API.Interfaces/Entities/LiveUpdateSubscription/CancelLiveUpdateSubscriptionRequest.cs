namespace PetsOnTrail.Interfaces.Actions.Entities.LiveUpdateSubscription;

public sealed record CancelLiveUpdateSubscriptionRequest
{
    public string Peer { get; set; }
}