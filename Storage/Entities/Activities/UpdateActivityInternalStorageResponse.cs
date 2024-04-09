namespace Storage.Entities.Activities;

public sealed record UpdateActivityInternalStorageResponse
{
    public Guid Id { get; set; } = Guid.Empty;
}