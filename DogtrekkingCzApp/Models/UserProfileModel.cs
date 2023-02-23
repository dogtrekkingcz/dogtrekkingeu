namespace DogtrekkingCzApp.Models;

public sealed record UserProfileModel
{
    public string Id { get; set; }
    public string UserId { get; set; }
    public Guid? CompetitorId { get; set; }

    public string Email { get; set; }
    
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Nickname { get; set; }
    
    public DateTimeOffset Birthday { get; set; }
    
    public AddressDto Address { get; set; }
    public ContactDto Contact { get; set; }
    public IList<DogDto> Dogs { get; set; }

    public sealed record AddressDto
    {
        public string Street { get; set; }
        public string City { get; set; }
    }

    public sealed record ContactDto
    {
        public string Phone { get; set; }
        public string Mail { get; set; }
    }

    public sealed record DogDto
    {
        public string Name { get; set; }
        public string Kennel { get; set; }
        public string ChipNumber { get; set; }
        public string Pedigree { get; set; }
    }
}