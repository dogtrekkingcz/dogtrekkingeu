namespace SharedCode.Extensions
{
    public static class GoogleDateTimeOffsetExtension
    {
        public static DateTimeOffset? ToDatdddeTimeOffset(this Google.Type.DateTime value)
        {
            if (value == null)
                return null;
            
            return new DateTime(value.Year, value.Month, value.Day, value.Hours, value.Minutes, value.Seconds);
        }
    }
}
