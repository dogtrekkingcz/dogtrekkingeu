namespace Storage.Entities.Dogs
{
    public sealed record DeleteDogRequest
    {
        public string Id { get; set; }
    }
}
