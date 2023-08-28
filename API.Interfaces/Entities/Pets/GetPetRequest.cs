namespace DogsOnTrail.Interfaces.Actions.Entities.Pets;

public sealed record GetPetRequest
{
    public Guid Id { get; set; } = Guid.Empty;
}