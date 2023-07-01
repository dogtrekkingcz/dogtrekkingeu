namespace SharedCode.Entities
{
    public sealed record AddressDto
    {
        public string Country { get; set; } = string.Empty;

        public string Region { get; set; } = string.Empty;

        public string ZipCode { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string Street { get; set; } = string.Empty;

        public LatLngDto Position { get; set; } = new();
    }
}
