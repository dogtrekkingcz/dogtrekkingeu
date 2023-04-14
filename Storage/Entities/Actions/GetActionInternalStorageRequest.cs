namespace Storage.Entities.Actions;

public sealed record GetActionInternalStorageRequest
{
    public Guid Id { get; set; }
}