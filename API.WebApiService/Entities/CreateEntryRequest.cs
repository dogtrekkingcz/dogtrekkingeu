using Mediator;

namespace API.WebApiService.Entities;

public sealed record CreateEntryRequest : IRequest<CreateEntryResponse>
{
    public string LanguageCode { get; set; } = "en-US";
    
    public string UserId { get; set; } = "";
    
    public string CompetitorId { get; set; } = "";

    public string FirstName { get; set; } = "";

    public string LastName { get; set; } = "";

    public string Phone { get; set; } = "";

    public string Email { get; set; } = "";

    public IEnumerable<PetDto> Pets { get; set; } = new List<PetDto>(0);

    public List<string> Notes { get; set; } = new List<string>(0);

    public Guid ActionId { get; set; } = Guid.Empty;

    public Guid RaceId { get; set; } = Guid.Empty;

    public Guid CategoryId { get; set; } = Guid.Empty;

    public AddressDto Address { get; set; } = new();

    public DateTimeOffset? Birthday { get; set; } = null;
    
    public bool Accepted { get; set; } = false;
    
    public DateTimeOffset? AcceptedDate { get; set; } = null;

    public IEnumerable<MerchandizeItemDto> Merchandize { get; set; } = new List<MerchandizeItemDto>(0);
    
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