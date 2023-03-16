namespace DogtrekkingCz.Shared.Entities
{
    public record UserProfileDto
    {
        public string? Id { get; set; }

        public string UserId { get; set; }

        public Guid CompetitorId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Nickname { get; set; }

        public DateTimeOffset Birthday { get; set; }

        public AddressDto Address { get; set; }

        public ContactDto Contact { get; set; }

        public List<string> Dogs { get; set; }
    }
}
