namespace DogtrekkingCz.Shared.Entities
{
    public sealed record CategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IList<RacerDto> Racers { get; set; } = new List<RacerDto>();
    }
}
