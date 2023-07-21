namespace DogsOnTrailGRPCService.Extensions
{
    public static class GoogleDateTimeOffsetExtension
    {
        public static DateTimeOffset? ToDateTimeOffset(this Google.Type.DateTime value)
        {
            if (value == null)
                return null;
            
            return new DateTime(value.Year, value.Month, value.Day, value.Hours, value.Minutes, value.Seconds);
        }
    }
}
