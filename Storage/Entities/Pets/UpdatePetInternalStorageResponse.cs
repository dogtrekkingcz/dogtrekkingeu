namespace Storage.Entities.Pets
{
    public sealed record UpdatePetInternalStorageResponse
    {
        public Guid Id { get; set; } = Guid.Empty;
    }
}
