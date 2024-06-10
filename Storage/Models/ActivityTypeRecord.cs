namespace Storage.Models;

internal sealed record ActivityTypeRecord : BaseRecord, IRecord
{
    public string Name { get; init; } = "";

    public string Description { get; init; } = "";

    public string AdapterPrefix { get; init; } = "";

    public string IconPath { get; init; } = "";

    public bool TimeTracking { get; init; } = false;

    public bool DistanceTracking { get; init; } = false;

    public bool SpeedTracking { get; init; } = false;

    public bool PointTracking { get; init; } = false;
    
}