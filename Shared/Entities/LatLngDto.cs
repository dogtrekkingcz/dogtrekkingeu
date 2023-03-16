namespace DogtrekkingCz.Shared.Entities
{
    public sealed record LatLngDto
    {
        public double GpsLatitude { get; set; }

        public double GpsLongitude { get; set; }
    }
}
