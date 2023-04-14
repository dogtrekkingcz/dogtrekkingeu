namespace Storage.Entities.Actions;

public sealed record DeleteActionInternalStorageRequest
{
    public required string Id { get; set; }
}