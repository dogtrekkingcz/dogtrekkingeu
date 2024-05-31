namespace Storage.Entities.PetTypes;

public record GetPetTypesInternalStorageResponse
{
    public IList<PetTypeDto> PetTypes { get; init; } = new List<PetTypeDto>();

    public record PetTypeDto
    {
        public string? Id { get; init; }

        public string UserId { get; init; } = string.Empty;

        public string Name { get; init; } = string.Empty;

        public string Description { get; init; } = string.Empty;
    }
}

