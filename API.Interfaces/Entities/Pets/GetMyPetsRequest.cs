namespace PetsOnTrail.Interfaces.Actions.Entities.Pets;

public sealed record GetMyPetsRequest
{
    public Guid UserId { get; init; }
}
