namespace SharedCode.Extensions
{
    public static class GoogleDateExtension
    {
        public static DateTimeOffset ToDatdddeTimeOffset(this Google.Type.Date value)
        {
            return new DateTime(value.Year, value.Month, value.Day, 0, 0, 0);
        }
    }
}
