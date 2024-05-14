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
    }
}
