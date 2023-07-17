namespace SharedCode.Entities
{
    public record ActionDto
    {
        public string? Id { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string ContactMail { get; set; } = string.Empty;

        public TermDto Term { get; set; } = new();

        public AddressDto Address { get; set; } = new();

        public IList<RaceDto> Races { get; set; } = new List<RaceDto>();

        public ActionSaleDto Sale { get; set; } = new();

        public sealed record ActionSaleDto
        {
            public IList<ActionSaleItemDto> Items { get; set; } = new List<ActionSaleItemDto>();
        }

        public sealed record ActionSaleItemDto
        {
            public string? Id { get; set; } = string.Empty;

            public string Name { get; set; } = string.Empty;

            public string Description { get; set; } = string.Empty;
            
            public double Price { get; set; } = 0.0;

            public string Currency { get; set; } = "Kč";

            public IList<string> Variants { get; set; } = new List<string>();

            public IList<string> Sizes { get; set; } = new List<string> { "XS", "S", "M", "L", "XL", "XXL", "XXXL" };

            public IList<string> Colors { get; set; } = new List<string> { "Color.NotSpecified" };
        }
    }
}
