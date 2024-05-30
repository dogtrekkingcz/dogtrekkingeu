namespace Storage.Entities.VaccinationTypes;

public record AddVaccinationTypeInternalStorageResponse
{
    public string? Id { get; init; }

    public string UserId { get; init; } = string.Empty;

    public string Name { get; init; } = string.Empty;

    public string Description { get; init; } = string.Empty;

    public Guid PetType { get; init; } = Guid.Empty;
}
