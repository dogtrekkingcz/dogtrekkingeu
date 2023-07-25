namespace Storage.Entities.UserProfiles;

public sealed record UpdateUserProfileInternalStorageRequest
{
    public string? Id { get; set; } = string.Empty;

    public string UserId { get; set; } = string.Empty;

    public Guid CompetitorId { get; set; } = default(Guid);

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Nickname { get; set; } = string.Empty;

    public DateTimeOffset? Birthday { get; set; } = null;

    public AddressDto Address { get; set; } = new();

    public ContactDto Contact { get; set; } = new();

    public List<DogDto> Dogs { get; set; } = new List<DogDto>();
    
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
        public double GpsLatitude { get; set; } = 0.0;

        public double GpsLongitude { get; set; } = 0.0;
    }
    
    public sealed record ContactDto
    {
        public string PhoneNumber { get; set; } = string.Empty;

        public string EmailAddress { get; set; } = string.Empty;
    }

    public record DogDto
    {
        public string? Id { get; set; }

        public string UserId { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Kennel { get; set; } = string.Empty;

        public string Pedigree { get; set; } = string.Empty;

        public string Chip { get; set; } = string.Empty;

        public DateTimeOffset? Birthday { get; set; } = null;

        public DateTimeOffset? Decease { get; set; } = null;

        public string UriToPhoto { get; set; } = string.Empty;

        public string Contact { get; set; } = string.Empty;
    }
    
    public List<VaccinationDto> Vaccinations { get; set; } = new List<VaccinationDto>
    {
        new VaccinationDto
        {
            Type = VaccinationType.Rabies
        }
    };

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
}