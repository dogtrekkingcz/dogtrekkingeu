namespace Storage.Entities.UserProfiles;

public sealed record CreateUserProfileInternalStorageRequest
{
    public Guid Id { get; init; } = Guid.Empty;

    public Guid UserId { get; init; } = Guid.Empty;

    public string Email { get; init; } = string.Empty;

    public Guid CompetitorId { get; init; } = default(Guid);

    public string FirstName { get; init; } = string.Empty;

    public string LastName { get; init; } = string.Empty;

    public string Nickname { get; init; } = string.Empty;

    public DateTimeOffset? Birthday { get; init; } = null;

    public AddressDto Address { get; init; } = new();

    public ContactDto Contact { get; init; } = new();

    public List<PetDto> Pets { get; init; } = new List<PetDto>();

    public List<Guid> Roles { get; init; } = new List<Guid>();

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
    
    public record PetDto
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

        public List<PositionDto> Positions { get; init; } = new List<PositionDto>(0);

        public List<ActivityPetDto> Pets { get; init; } = new List<ActivityPetDto>(0);
    }
    public sealed record PositionDto
    {
        public string Id { get; init; } = Guid.NewGuid().ToString();

        public DateTimeOffset Time { get; init; } = DateTimeOffset.Now;

        public double Latitude { get; init; } = double.NaN;

        public double Longitude { get; init; } = double.NaN;

        public double Altitude { get; init; } = double.NaN;

        public double Accuracy { get; init; } = double.NaN;

        public double Course { get; init; } = double.NaN;

        public string Note { get; init; } = string.Empty;

        public List<string> PhotoUris { get; init; } = new();
    }

    public sealed record ActivityPetDto
    {
        public string Id { get; init; } = Guid.NewGuid().ToString();

        public string? Chip { get; init; }

        public string? Name { get; init; }

        public string? Breed { get; init; }

        public string? Color { get; init; }

        public string Kennel { get; init; }

        public DateTimeOffset? BirthDate { get; init; }
    }
}