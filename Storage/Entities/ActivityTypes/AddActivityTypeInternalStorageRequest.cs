namespace Storage.Entities.ActivityTypes;

public record AddActivityTypeInternalStorageRequest
{
    public string? Id { get; init; }

    public string UserId { get; init; } = string.Empty;

    public string Name { get; init; } = string.Empty;

    public string Description { get; init; } = string.Empty;

    public string AdapterPrefix { get; init; } = string.Empty;

    public string IconPath { get; init; } = string.Empty;

    public bool TimeTracking { get; init; } = false;

    public bool DistanceTracking { get; init; } = false;

    public bool SpeedTracking { get; init; } = false;

    public bool PointTracking { get; init; } = false;
}
