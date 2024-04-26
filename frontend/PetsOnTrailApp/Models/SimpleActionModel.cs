using Protos.Actions.CreateAction;

namespace PetsOnTrailApp.Models;

public sealed record SimpleActionModel : BaseSynchronizedModel
{
    public Guid Id { get; init; }

    public string Name { get; init; }

    public string Description { get; init; }

    public string City { get; init; }

    public DateTime Begin { get; init; }

    public DateTime End { get; init; }

    public Guid Type { get; init; }

    public IList<RaceDto> Races { get; init; }

    public sealed record RaceDto
    {
        public Guid Id { get; init; }

        public string Name { get; init; }
    }
}
