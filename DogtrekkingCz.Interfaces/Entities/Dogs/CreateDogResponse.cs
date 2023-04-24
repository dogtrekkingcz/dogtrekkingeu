using DogtrekkingCzShared.Entities;

namespace DogtrekkingCz.Interfaces.Actions.Entities.Dogs;

public record CreateDogResponse
{
    public string Id { get; init; }
}