namespace SharedCode.Entities
{
    public sealed record Category___Dto
    {
        public Guid Id { get; set; } = default(Guid);

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public IList<Racer___Dto> Racers { get; set; } = new List<Racer___Dto>();
    }
}
