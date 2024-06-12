namespace Storage.Entities.Pets
{
    public sealed record AddPetInternalStorageResponse
    {
        public Guid Id { get; init; } = Guid.Empty;
    }
}
