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

    public string ActionId { get; set; } = "";

    public string RaceId { get; set; } = "";

    public string CategoryId { get; set; } = "";

    public AddressDto Address { get; set; } = new();

    public DateTimeOffset? Birthday { get; set; } = null;
    
    public DateTimeOffset Created { get; set; } = DateTimeOffset.Now;

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
}