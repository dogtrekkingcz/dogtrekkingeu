namespace SharedCode.Entities
{
    public record UserProfileDto
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
    }
}
