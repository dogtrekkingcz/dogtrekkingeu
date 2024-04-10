namespace Storage.Entities.Actions;

public record AddResultInternalStorageRequest
{
    public Guid Id { get; set; } = Guid.Empty;
    
    public string UserId { get; set; }
    
    public Guid ActionId { get; set; } = Guid.Empty;

    public Guid RaceId { get; set; } = Guid.Empty;

    public Guid CategoryId { get; set; } = Guid.Empty;
    
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public DateTimeOffset? Start { get; set; } = null;

    public DateTimeOffset? Finish { get; set; } = null;

    public FinalState State { get; set; } = FinalState.Finished;
    
    public enum FinalState {
        NotSpecified = 0,
        Accepted = 1,
        Started = 2,
        Finished = 3,
        DNF = 4,
        DNS = 5,
        DSQ = 6
    }
}