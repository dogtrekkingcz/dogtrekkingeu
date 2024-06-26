namespace PetsOnTrail.Interfaces.Actions.Entities.Actions;

public sealed record AddNewResultRequest
{
    public Guid Id { get; init; } = default(Guid);
    public Guid ActionId { get; init; } = default(Guid);
    public Guid RaceId { get; init; } = default(Guid);
    public Guid CategoryId { get; init; } = default(Guid);
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;
    public List<string> Pets { get; init; } = new();
    public RaceState State { get; init; } = RaceState.NotSpecified;
    public DateTimeOffset? Start { get; init; } = null;
    public DateTimeOffset? Finish { get; init; } = null;

    public enum RaceState
    {
        NotSpecified = 0,
        NotStarted = 1,
        Started = 2,
        Finished = 3,
        DidNotFinished = 4,
        Disqualified = 5
    }
}