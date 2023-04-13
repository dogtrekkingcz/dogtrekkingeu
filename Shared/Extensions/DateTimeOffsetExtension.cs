namespace DogtrekkingCzShared.Extensions
{
    public static class DateTimeOffsetExtension
    {
        public static Google.Type.DateTime ToGoogleDateTime(this DateTimeOffset value)
        {
            return new Google.Type.DateTime
            {
                Year = value.Year,
                Month = value.Month,
                Day = value.Day,
                Hours = value.Hour,
                Minutes = value.Minute,
                Seconds = value.Second
            };
        }

        public static Google.Protobuf.WellKnownTypes.Timestamp ToGoogleTimestamp(this DateTimeOffset value)
        {
            return new Google.Protobuf.WellKnownTypes.Timestamp
            {
                Seconds = value.ToUnixTimeSeconds()
            };
        }
    }
}
