namespace Storage.Entities.Dogs
{
    public sealed record DeleteDogInternalStorageRequest
    {
        public string Id { get; set; }
    }
}
