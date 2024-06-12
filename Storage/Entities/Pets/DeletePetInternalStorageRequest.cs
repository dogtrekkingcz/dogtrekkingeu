namespace Storage.Entities.Pets
{
    public sealed record DeletePetInternalStorageRequest
    {
        public Guid Id { get; set; } = Guid.Empty;
    }
}
