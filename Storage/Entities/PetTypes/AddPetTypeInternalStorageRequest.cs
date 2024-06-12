namespace Storage.Entities.PetTypes;

public record AddPetTypeInternalStorageRequest
{
    public Guid Id { get; init; } = Guid.Empty;

    public Guid UserId { get; init; } = Guid.Empty;

    public string Name { get; init; } = string.Empty;

    public string Description { get; init; } = string.Empty;
}
