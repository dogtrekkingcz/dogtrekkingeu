namespace SharedCode.Entities;

public record EntryDto
{
    public string? Id { get; set; } = "";

    public string UserProfileId { get; set; } = "";
    
    public string CompetitorId { get; set; } = "";

    public string Name { get; set; } = "";

    public string Surname { get; set; } = "";

    public string Phone { get; set; } = "";

    public string Email { get; set; } = "";

    public List<DogDto> Dogs { get; set; } = new List<DogDto>();

    public List<string> Notes { get; set; } = new List<string>();

    public Guid ActionId { get; set; } = Guid.Empty;

    public Guid RaceId { get; set; } = Guid.Empty;

    public Guid CategoryId { get; set; } = Guid.Empty;

    public AddressDto Address { get; set; } = new();

    public DateTimeOffset? Birthday { get; set; } = null;
    
    public DateTimeOffset Created { get; set; } = DateTimeOffset.Now;

    public string LanguageCode { get; set; } = "en-US";

    public List<MerchandizeItemDto> Merchandize { get; set; } = new();
    
    public record DogDto
    {
        public string? Id { get; set; }
        
        public string Name { get; set; } = string.Empty;

        public string Pedigree { get; set; } = string.Empty;

        public string Chip { get; set; } = string.Empty;

        public DateTimeOffset? Birthday { get; set; } = null;

        public List<Entities.DogDto.VaccinationDto> Vaccinations { get; set; } =
            new List<Entities.DogDto.VaccinationDto>
            {
                new Entities.DogDto.VaccinationDto
                {
                    Type = Entities.DogDto.VaccinationType.Rabies
                }
            };
    }
    
    public sealed record MerchandizeItemDto
    {
        public string? Id { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
            
        public double Price { get; set; } = 0.0;

        public string Currency { get; set; } = "Kč";

        public string Variant { get; set; } = string.Empty;

        public string Size { get; set; } = string.Empty;

        public string Color { get; set; } = string.Empty;

        public int Count { get; set; } = 0;

        public string Note { get; set; } = string.Empty;
    }
}