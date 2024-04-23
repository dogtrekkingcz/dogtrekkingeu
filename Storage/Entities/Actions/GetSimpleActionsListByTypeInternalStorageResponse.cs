namespace Storage.Entities.Actions;

public sealed record GetSimpleActionsListByTypeInternalStorageResponse
{
    public IList<ActionDto> Actions { get; init; } = new List<ActionDto>();

    public record ActionDto
    {
        public Guid Id { get; init; }

        public string Name { get; init; }

        public string Description { get; init; }

        public string City { get; init; }

        public DateTime Begin { get; init; }

        public DateTime End { get; init; }

        public string Type { get; init; }

        public IList<RaceDto> Races { get; init; }
    }

    public sealed record RaceDto
    {
        public Guid Id { get; init; }

        public string Name { get; init; }
    }
}
