namespace DogtrekkingCz.Shared.Entities
{
    public sealed record AddressDto
    {
        public string Country { get; set; }

        public string Region { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public LatLngDto Position { get; set; } = new();
    }
}
