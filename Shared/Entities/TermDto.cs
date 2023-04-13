namespace DogtrekkingCzShared.Entities
{
    public sealed record TermDto
    {
        public DateTimeOffset From { get; set; } = DateTime.Now;

        public DateTimeOffset To { get; set; } = DateTime.Now.AddDays(3);
    }
}
