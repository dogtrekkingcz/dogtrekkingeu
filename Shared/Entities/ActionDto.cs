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

        public List<RaceDto> Races { get; set; } = new List<RaceDto>();

        public ActionSaleDto Sale { get; set; } = new();

        public sealed record ActionSaleDto
        {
            public List<ActionSaleItemDto> Items { get; set; } = new List<ActionSaleItemDto>();
        }

        public sealed record ActionSaleItemDto
        {
            public string? Id { get; set; } = string.Empty;

            public string Name { get; set; } = string.Empty;

            public string Description { get; set; } = string.Empty;
            
            public double Price { get; set; } = 0.0;

            public string Currency { get; set; } = "Kč";

            public List<string> Variants { get; set; } = new List<string>();

            public List<string> Sizes { get; set; } = new List<string>();

            public List<string> Colors { get; set; } = new List<string>();
        }
    }
}
