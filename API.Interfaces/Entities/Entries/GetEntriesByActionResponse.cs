namespace DogsOnTrail.Interfaces.Actions.Entities.Entries;

public sealed record GetEntriesByActionResponse
{
    public List<EntryDto> Entries { get; init; } = new();
    
    public sealed record EntryDto
    {
        public string? Id { get; set; } = "";

        public EntryState State { get; set; } = EntryState.Unspecified;

        public string UserProfileId { get; set; } = "";

        public string CompetitorId { get; set; } = "";

        public string Name { get; set; } = "";

        public string Surname { get; set; } = "";

        public string Phone { get; set; } = "";

        public string Email { get; set; } = "";

        public List<PetDto> Pets { get; set; } = new List<PetDto>();

        public List<string> Notes { get; set; } = new List<string>();

        public Guid ActionId { get; set; } = Guid.Empty;

        public Guid RaceId { get; set; } = Guid.Empty;

        public Guid CategoryId { get; set; } = Guid.Empty;

        public AddressDto Address { get; set; } = new();

        public DateTimeOffset? Birthday { get; set; } = null;

        public DateTimeOffset Created { get; set; } = DateTimeOffset.Now;

        public bool Accepted { get; set; } = false;

        public DateTimeOffset? AcceptedDate { get; set; } = null;

        public string LanguageCode { get; set; } = "en-US";

        public List<MerchandizeItemDto> Merchandize { get; set; } = new();
    }
    
    public enum EntryState
    {
        Unspecified = 0,
        Entered = 1,
        Accepted = 2,
        Paid = 3,
        NotAccepted = 4
    }
    
    public sealed record AddressDto
    {
        public string Country { get; set; } = string.Empty;

        public string Region { get; set; } = string.Empty;

        public string ZipCode { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string Street { get; set; } = string.Empty;

        public LatLngDto Position { get; set; } = new();
    }

    public sealed record LatLngDto
    {
        public double Latitude { get; set; } = 0.0;

        public double Longitude { get; set; } = 0.0;
    }
    
    public record PetDto
    {
        public string? Id { get; set; }
        
        public string Name { get; set; } = string.Empty;

        public string Pedigree { get; set; } = string.Empty;

        public string Chip { get; set; } = string.Empty;

        public DateTimeOffset? Birthday { get; set; } = null;

        public List<VaccinationDto> Vaccinations { get; set; } = new List<VaccinationDto>();
    }
    
    public sealed record VaccinationDto
    {
        public DateTimeOffset? Date { get; set; } = DateTimeOffset.Now;

        public DateTimeOffset? ValidUntil { get; set; } = DateTimeOffset.Now;

        public VaccinationType Type { get; set; } = VaccinationType.NotValid;

        public string UriToPhoto { get; set; } = string.Empty;

        public string Note { get; set; } = string.Empty;
    }

    public enum VaccinationType
    {
        NotValid = 0,
        Rabies = 1, // Vzteklina
        Psinka = 2,
        Parvoviroza = 3,
        HepatitidaContagiosaCanis = 4,
        Leptospiroza = 5,
        Parainfluenza = 6,
        LymskaBorelioza = 7,
        Babesioza = 8,
        PlisnoveInfekce = 9,
        Leishmanioza = 10
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