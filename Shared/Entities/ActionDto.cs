namespace DogtrekkingCz.Shared.Entities
{
    public record ActionDto
    {
        public string? Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public TermDto Term { get; set; }

        public AddressDto Address { get; set; }

        public IList<RaceDto> Races { get; set; }
    }
}
