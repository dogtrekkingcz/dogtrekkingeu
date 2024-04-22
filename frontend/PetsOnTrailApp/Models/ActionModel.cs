namespace PetsOnTrailApp.Models;

public sealed record ActionModel : BaseSynchronizedModel
{
    public Guid Id { get; init; }

    public string Name { get; init; }

    public string Description { get; init; }

    public string City { get; init; }

    public DateTime Begin { get; init; }

    public DateTime End { get; init; }

    public ActionType Type { get; init; }


    public enum ActionType
    {
        Unspecified = 0,
        Trip = 1,
        Dogtrekking = 2,
        RallyObedience = 3,
        Obedience = 4,
        Agility = 5,
        Mushing = 6,
        HorseMountainTrail = 7
    }
}
