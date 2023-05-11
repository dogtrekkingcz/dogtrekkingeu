using SharedCode.Entities;

namespace DogsOnTrail.Interfaces.Actions.Entities.Dogs;

public record CreateDogResponse
{
    public string Id { get; init; }
}