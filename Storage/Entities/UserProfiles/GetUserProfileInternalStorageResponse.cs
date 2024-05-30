namespace Storage.Entities.UserProfiles;

public sealed record GetUserProfileInternalStorageResponse
{
    public string? Id { get; set; } = string.Empty;

    public string UserId { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public Guid CompetitorId { get; set; } = default(Guid);

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Nickname { get; set; } = string.Empty;

    public DateTimeOffset? Birthday { get; set; } = null;

    public AddressDto Address { get; set; } = new();

    public ContactDto Contact { get; set; } = new();

    public List<PetDto> Pets { get; set; } = new List<PetDto>();

    public List<string> Roles { get; set; } = new List<string>();

    public List<ActivityDto> Activities { get; set; } = new List<ActivityDto>();
    
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
    
    public sealed record ContactDto
    {
        public string PhoneNumber { get; set; } = string.Empty;

        public string EmailAddress { get; set; } = string.Empty;
    }

    public record PetDto
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

        public Guid PetType { get; set; } = Guid.Empty;

        public List<VaccinationDto> Vaccinations { get; set; } = new List<VaccinationDto>();
    }

    public sealed record VaccinationDto
    {
        public DateTimeOffset? Date { get; set; } = DateTimeOffset.Now;

        public DateTimeOffset? ValidUntil { get; set; } = DateTimeOffset.Now;

        public Guid VaccinationType { get; set; } = Guid.Empty;

        public string UriToPhoto { get; set; } = string.Empty;

        public string Note { get; set; } = string.Empty;
    }

    public sealed record ActivityDto
    {
        public string? Id { get; set; }

        public string UserId { get; set; } = string.Empty;

        public string ActionId { get; set; } = Guid.Empty.ToString();

        public string RaceId { get; set; } = Guid.Empty.ToString();

        public string CategoryId { get; set; } = Guid.Empty.ToString();

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public DateTimeOffset Start { get; set; } = DateTimeOffset.Now;

        public DateTimeOffset? End { get; set; } = null;

        public bool IsPublic { get; set; } = true;

        public List<PositionDto> Positions { get; set; } = new List<PositionDto>(0);

        public List<ActivityPetDto> Pets { get; set; } = new List<ActivityPetDto>(0);
    }
    public sealed record PositionDto
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public DateTimeOffset Time { get; set; } = DateTimeOffset.Now;

        public double Latitude { get; set; } = double.NaN;

        public double Longitude { get; set; } = double.NaN;

        public double Altitude { get; set; } = double.NaN;

        public double Accuracy { get; set; } = double.NaN;

        public double Course { get; set; } = double.NaN;

        public string Note { get; set; } = string.Empty;

        public List<string> PhotoUris { get; set; } = new();
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