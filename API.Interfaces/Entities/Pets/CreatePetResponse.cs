namespace PetsOnTrail.Interfaces.Actions.Entities.Pets;

public sealed record CreatePetResponse
{
    public Guid Id { get; init; } = Guid.Empty;
}