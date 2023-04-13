namespace DogtrekkingCzShared.Entities
{
    public sealed record CategoryDto
    {
        public Guid Id { get; set; } = default(Guid);

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public IList<RacerDto> Racers { get; set; } = new List<RacerDto>();
    }
}
