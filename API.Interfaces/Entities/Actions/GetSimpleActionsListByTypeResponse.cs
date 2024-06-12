namespace PetsOnTrail.Interfaces.Actions.Entities.Actions;

public sealed record GetSimpleActionsListByTypeResponse
{
    public IList<ActionDto> Actions { get; init; } = new List<ActionDto>();

    public record ActionDto
    {
        public Guid Id { get; init; }

        public string Name { get; init; } = string.Empty;

        public string Description { get; init; } = string.Empty;

        public string City { get; init; } = string.Empty;

        public DateTime Begin { get; init; }

        public DateTime End { get; init; }

        public Guid TypeId { get; init; }

        public IList<RaceDto> Races { get; init; } = new List<RaceDto>();
    }

    public sealed record RaceDto
    {
        public Guid Id { get; init; }

        public string Name { get; init; } = string.Empty;
    }
}
