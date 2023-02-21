using DogtrekkingCz.Storage.Models;

namespace Storage.Entities.Actions;

public sealed record GetAllActionsResponse
{
    public IReadOnlyList<ActionDto> Actions { get; init; }

    public sealed record ActionDto
    {
        public string Id { get; set; }
        
        public string Name { get; set; }

        public OwnerDto Owner { get; set; }

        public string Description { get; set; }
        
        public TermDto Term { get; set; }
        
        public AddressDto Address { get; set; }
    }

    public sealed record OwnerDto
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string FamilyName { get; set; }
    }

    public sealed record TermDto
    {
        public DateTimeOffset From { get; set; }
        public DateTimeOffset To { get; set; }
    }
    
    public sealed record AddressDto
    {
        public string Country { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public double GpsLatitude { get; set; }
        public double GpsLongitude { get; set; }
    }
}