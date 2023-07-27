namespace DogsOnTrail.Interfaces.Actions.Entities.LiveUpdateSubscription;

public sealed record LiveUpdateSubscriptionItem
{
    public DateTimeOffset ServerTime { get; set; }
    
    public TypeOfMessage Type { get; set; }
    
    public string From { get; set; }

    public string Message { get; set; }
    
    public enum TypeOfMessage {
        TypeOfMessage_NotSpecified = 0,
        Chat = 1,
        Info = 2,
        Alert = 3,
        Error = 4,
        RequestForReloadApp = 5,
        RequestForReloadPage = 6
    }
}