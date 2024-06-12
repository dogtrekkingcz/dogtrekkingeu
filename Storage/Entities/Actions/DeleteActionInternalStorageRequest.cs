namespace Storage.Entities.Actions;

public sealed record DeleteActionInternalStorageRequest
{
    public required Guid Id { get; set; } = Guid.Empty;
}