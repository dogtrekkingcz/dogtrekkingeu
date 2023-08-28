namespace Storage.Entities.Pets;

public sealed record GetPetInternalStorageRequest
{
    public Guid Id { get; set; } = Guid.Empty;
}