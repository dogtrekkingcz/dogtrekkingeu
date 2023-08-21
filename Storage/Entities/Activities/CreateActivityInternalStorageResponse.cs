namespace Storage.Entities.Activities;

public sealed record CreateActivityInternalStorageResponse
{
    public Guid Id { get; set; } = Guid.Empty;
}