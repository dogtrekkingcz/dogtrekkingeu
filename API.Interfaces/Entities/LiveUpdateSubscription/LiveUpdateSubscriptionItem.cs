namespace PetsOnTrail.Interfaces.Actions.Entities.LiveUpdateSubscription;

public sealed record LiveUpdateSubscriptionData
{
    public LiveUpdateSubscriptionSettingsDto Settings { get; set; } = new();
    
    public List<LiveUpdateSubscriptionItemDto> Items { get; set; } = new();

    public sealed record LiveUpdateSubscriptionSettingsDto
    {
        public Guid? User { get; set; }
        
        public string? Section { get; set; }
        
        public DateTimeOffset Subscribed { get; set; } = DateTimeOffset.Now;
    }
    
    public sealed record LiveUpdateSubscriptionItemDto
    {
        public DateTimeOffset ServerTime { get; set; }

        public TypeOfMessage Type { get; set; }

        public string? Section { get; set; }

        public Guid? User { get; set; }

        public Guid From { get; set; }

        public string Message { get; set; }
    }
    
    public enum TypeOfMessage
    {
        TypeOfMessage_NotSpecified = 0,
        Chat = 1,
        Info = 2,
        Alert = 3,
        Error = 4,
        RequestForReloadApp = 5,
        RequestForReloadPage = 6
    }
}