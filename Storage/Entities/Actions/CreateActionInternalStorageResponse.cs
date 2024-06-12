namespace Storage.Entities.Actions;

public sealed record CreateActionInternalStorageResponse
{
    public Guid Id { get; set; } = Guid.Empty;
}