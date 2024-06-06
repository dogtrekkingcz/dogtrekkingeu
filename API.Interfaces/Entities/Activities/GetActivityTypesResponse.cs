namespace PetsOnTrail.Interfaces.Actions.Entities.Activities;

public sealed record GetActivityTypesResponse
{
    public List<ActivityTypeDto> ActivityTypes { get; init; } = new();

    public sealed record ActivityTypeDto
    {
        public string? Id { get; init; } = "";

        public string UserId { get; init; } = "";

        public string Name { get; init; } = "";

        public string Description { get; init; } = "";

        public string AdapterPrefix { get; init; } = "";

        public string IconPath { get; init; } = "";

        public bool TimeTracking { get; init; } = false;

        public bool DistanceTracking { get; init; } = false;

        public bool SpeedTracking { get; init; } = false;

        public bool PointTracking { get; init; } = false;
    }
}
