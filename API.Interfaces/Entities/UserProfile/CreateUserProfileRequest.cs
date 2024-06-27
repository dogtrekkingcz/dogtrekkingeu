namespace PetsOnTrail.Interfaces.Actions.Entities.UserProfile;

public sealed record CreateUserProfileRequest
{
    public string? Id { get; init; } = string.Empty;

    public string UserId { get; init; } = string.Empty;

    public string Email { get; init; } = string.Empty;

    public Guid CompetitorId { get; init; } = default(Guid);

    public string FirstName { get; init; } = string.Empty;

    public string LastName { get; init; } = string.Empty;

    public string Nickname { get; init; } = string.Empty;

    public DateTimeOffset? Birthday { get; init; } = null;

    public AddressDto Address { get; init; } = new();

    public ContactDto Contact { get; init; } = new();

    public List<PetDto> Pets { get; init; } = new List<PetDto>();

    public List<string> Roles { get; init; } = new List<string>();

    public List<ActivityDto> Activities { get; init; } = new List<ActivityDto>();
    
    public sealed record AddressDto
    {
        public string Country { get; init; } = string.Empty;

        public string Region { get; init; } = string.Empty;

        public string ZipCode { get; init; } = string.Empty;

        public string City { get; init; } = string.Empty;

        public string Street { get; init; } = string.Empty;

        public LatLngDto Position { get; init; } = new();
    }
    
    public sealed record LatLngDto
    {
        public double Latitude { get; init; } = 0.0;

        public double Longitude { get; init; } = 0.0;
    }
    
    public sealed record ContactDto
    {
        public string PhoneNumber { get; init; } = string.Empty;

        public string EmailAddress { get; init; } = string.Empty;
    }
    
    public sealed record PetDto
    {
        public string? Id { get; init; }

        public string UserId { get; init; } = string.Empty;

        public string Name { get; init; } = string.Empty;

        public string Kennel { get; init; } = string.Empty;

        public string Pedigree { get; init; } = string.Empty;

        public string Chip { get; init; } = string.Empty;

        public DateTimeOffset? Birthday { get; init; } = null;

        public DateTimeOffset? Decease { get; init; } = null;

        public string UriToPhoto { get; init; } = string.Empty;

        public string Contact { get; init; } = string.Empty;

        public Guid PetType { get; init; } = Guid.Empty;

        public List<VaccinationDto> Vaccinations { get; init; } = new List<VaccinationDto>();
    }
    
    public sealed record VaccinationDto
    {
        public DateTimeOffset? Date { get; init; } = DateTimeOffset.Now;

        public DateTimeOffset? ValidUntil { get; init; } = DateTimeOffset.Now;

        public Guid VaccinationType { get; init; } = Guid.Empty;

        public string UriToPhoto { get; init; } = string.Empty;

        public string Note { get; init; } = string.Empty;
    }

    public sealed record ActivityDto
    {
        public string? Id { get; init; }

        public Guid UserId { get; init; } = Guid.Empty;

        public Guid ActionId { get; init; } = Guid.Empty;

        public Guid RaceId { get; init; } = Guid.Empty;

        public Guid CategoryId { get; init; } = Guid.Empty;

        public Guid TypeId { get; init; } = Guid.Empty;

        public string Name { get; init; } = string.Empty;

        public string Description { get; init; } = string.Empty;

        public DateTimeOffset Start { get; init; } = DateTimeOffset.Now;

        public DateTimeOffset? End { get; init; } = null;

        public bool IsPublic { get; init; } = true;
    }
}
