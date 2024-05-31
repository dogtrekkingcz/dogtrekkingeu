namespace Storage.Entities.PetTypes;

public record AddPetTypeInternalStorageRequest
{
    public string? Id { get; init; }

    public string UserId { get; init; } = string.Empty;

    public string Name { get; init; } = string.Empty;

    public string Description { get; init; } = string.Empty;
}
