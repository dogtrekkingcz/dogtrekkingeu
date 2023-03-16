namespace DogtrekkingCz.Shared.Entities
{
    public record ActionDto
    {
        public string? Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public TermDto Term { get; set; } = new();

        public AddressDto Address { get; set; } = new();

        public IList<RaceDto> Races { get; set; } = new List<RaceDto>();
    }
}
