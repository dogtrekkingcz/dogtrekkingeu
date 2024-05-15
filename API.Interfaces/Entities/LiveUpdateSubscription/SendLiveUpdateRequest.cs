namespace PetsOnTrail.Interfaces.Actions.Entities.LiveUpdateSubscription;

public sealed record SendLiveUpdateRequest
{
    public string? FromSection { get; set; } = null;

    public Guid? FromUser { get; set; } = null;
    
    public string? ToSection { get; set; } = null;

    public Guid? ToUser { get; set; } = null;

    public string Message { get; set; } = string.Empty;

    public string? Data { get; set; } = null;
}