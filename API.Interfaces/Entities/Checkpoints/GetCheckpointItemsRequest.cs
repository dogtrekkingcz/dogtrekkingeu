namespace DogsOnTrail.Interfaces.Actions.Entities.Checkpoints;

public sealed record GetCheckpointItemsRequest
{
    public DateTimeOffset From { get; set; }
}