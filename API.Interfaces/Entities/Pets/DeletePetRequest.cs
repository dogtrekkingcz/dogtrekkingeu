namespace PetsOnTrail.Interfaces.Actions.Entities.Pets;

public record DeletePetRequest
{
    public Guid Id { get; set; } = Guid.Empty;
}