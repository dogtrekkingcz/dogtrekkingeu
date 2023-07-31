namespace Storage.Entities.Checkpoints;

public sealed record GetCheckpointItemsInternalStorageRequest
{
    public DateTimeOffset From { get; set; }
}