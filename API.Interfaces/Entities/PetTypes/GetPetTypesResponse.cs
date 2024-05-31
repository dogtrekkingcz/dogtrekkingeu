namespace PetsOnTrail.Interfaces.Actions.Entities.PetTypes;

public record GetPetTypesResponse
{
    public IList<PetTypeDto> PetTypes { get; init; } = new List<PetTypeDto>();

    public record PetTypeDto
    {
        public Guid Id { get; init; }

        public string UserId { get; init; } = string.Empty;

        public string Name { get; init; } = string.Empty;

        public string Description { get; init; } = string.Empty;
    }
}

