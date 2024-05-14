namespace API.GRPCService.Extensions
{
    public static class GoogleDateTimeOffsetExtension
    {
        public static DateTimeOffset? ToDateTimeOffset(this Google.Type.DateTime value)
        {
            if (value == null)
                return null;
            
            return new DateTime(value.Year, value.Month, value.Day, value.Hours, value.Minutes, value.Seconds);
        }

        public static DateTimeOffset? ToDateTimeOffset(this Google.Protobuf.WellKnownTypes.Timestamp value)
        {
            if (value == null)
                return null;
            
            return new DateTimeOffset(value.Seconds, TimeSpan.FromSeconds(value.Nanos));
        }

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

        public static System.DateTimeOffset ToDateTimeOffsetNullable(this Google.Protobuf.WellKnownTypes.Timestamp? value)
        {
            if (value == null)
                return System.DateTimeOffset.MinValue;

            return new System.DateTimeOffset(value.Seconds, TimeSpan.FromSeconds(value.Nanos));
        }

        public static System.DateTime ToDateTime(this Google.Protobuf.WellKnownTypes.Timestamp value)
        {
            return new System.DateTime(value.Seconds, DateTimeKind.Utc);
        }

    }
}
