namespace SharedCode.Entities
{
    public record ActionDto
    {
        public string? Id { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public TermDto Term { get; set; } = new();

        public AddressDto Address { get; set; } = new();

        public IList<RaceDto> Races { get; set; } = new List<RaceDto>();
    }
}
