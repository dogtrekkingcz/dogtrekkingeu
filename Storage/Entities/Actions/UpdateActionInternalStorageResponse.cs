namespace Storage.Entities.Actions;

public sealed record UpdateActionInternalStorageResponse
{
    public Guid Id { get; init; } = Guid.Empty;
}