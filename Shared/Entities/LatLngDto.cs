namespace SharedCode.Entities
{
    public sealed record LatLngDto
    {
        public double GpsLatitude { get; set; } = 0.0;

        public double GpsLongitude { get; set; } = 0.0;
    }
}
