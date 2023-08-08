namespace DogsOnTrail.Interfaces.Actions.Entities.Actions;

public sealed record AcceptCheckpointRequest
{
    public Guid Id { get; set; }
}