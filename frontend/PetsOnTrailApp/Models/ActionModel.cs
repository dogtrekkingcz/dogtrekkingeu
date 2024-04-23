namespace PetsOnTrailApp.Models;

public sealed record ActionModel : BaseSynchronizedModel
{
    public Guid Id { get; init; }

    public string Name { get; init; }

    public string Description { get; init; }

    public string City { get; init; }

    public DateTime Begin { get; init; }

    public DateTime End { get; init; }

    public string Type { get; init; }
}
