namespace PetsOnTrail.Interfaces.Actions.Entities.Pets;

public sealed record UpdatePetResponse
{
    public Guid Id { get; init; } = Guid.Empty;
}