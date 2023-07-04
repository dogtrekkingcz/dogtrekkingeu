namespace Storage.Entities.Actions;

public sealed record GetSelectedActionsInternalStorageRequest
{
    public List<Guid> Ids { get; set; }
}