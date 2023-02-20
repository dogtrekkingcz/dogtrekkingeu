using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DogtrekkingCz.Storage.Models;

internal sealed record UserProfileRecord : BaseRecord
{
    public Guid UserId { get; set; }
    public Guid? CompetitorId { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Nickname { get; set; }
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