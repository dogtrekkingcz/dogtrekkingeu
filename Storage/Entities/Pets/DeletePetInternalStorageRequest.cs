namespace Storage.Entities.Pets
{
    public sealed record DeletePetInternalStorageRequest
    {
        public string Id { get; set; }
    }
}
