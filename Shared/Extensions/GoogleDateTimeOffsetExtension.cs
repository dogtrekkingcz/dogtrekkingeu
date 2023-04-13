namespace DogtrekkingCzShared.Extensions
{
    public static class GoogleDateTimeOffsetExtension
    {
        public static DateTimeOffset ToDateTimeOffset(this Google.Type.DateTime value)
        {
            return new DateTime(value.Year, value.Month, value.Day, value.Hours, value.Minutes, value.Seconds);
        }
    }
}
