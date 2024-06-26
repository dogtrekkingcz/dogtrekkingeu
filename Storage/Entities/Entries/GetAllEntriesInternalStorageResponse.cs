namespace Storage.Entities.Entries;

public sealed record GetAllEntriesInternalStorageResponse
{
    public IList<EntryDto> Entries { get; init; }

    public sealed record EntryDto
    {
        public Guid Id { get; set; } = Guid.Empty;

        public EntryState State { get; set; } = EntryState.Unspecified;

        public string UserId { get; set; } = "";

        public Guid CompetitorId { get; set; } = Guid.Empty;

        public string FirstName { get; set; } = "";

        public string LastName { get; set; } = "";

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
        public string Breed { get; set; } = string.Empty;
        public Guid PetType { get; set; } = Guid.Empty;
        public string Pedigree { get; set; } = string.Empty;
        public string Chip { get; set; } = string.Empty;
        public DateTimeOffset? Birthday { get; set; } = null;
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