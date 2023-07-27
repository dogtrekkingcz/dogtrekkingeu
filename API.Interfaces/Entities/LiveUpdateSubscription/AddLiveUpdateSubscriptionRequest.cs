namespace DogsOnTrail.Interfaces.Actions.Entities.LiveUpdateSubscription;

public sealed record AddLiveUpdateSubscriptionRequest
{
    public string Peer { get; set; } = string.Empty;

    public string UserId { get; set; } = string.Empty;

    public DateTimeOffset Created { get; set; }

    public string Section { get; set; }
    
    public string AdditionalInfo { get; set; }
}