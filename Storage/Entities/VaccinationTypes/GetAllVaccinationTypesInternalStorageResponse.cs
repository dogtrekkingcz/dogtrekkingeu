namespace Storage.Entities.VaccinationTypes;

public record GetAllVaccinationTypesInternalStorageResponse
{
    public IList<VaccinationTypeDto> VaccinationTypes { get; init; } = new List<VaccinationTypeDto>();

    public record VaccinationTypeDto
    {
        public string? Id { get; init; }

        public string UserId { get; init; } = string.Empty;

        public string Name { get; init; } = string.Empty;

        public string Description { get; init; } = string.Empty;

        public Guid PetType { get; init; } = Guid.Empty;
    }
}

