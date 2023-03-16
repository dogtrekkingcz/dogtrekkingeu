namespace DogtrekkingCz.Shared.Entities
{
    public sealed record TermDto
    {
        public DateTimeOffset From { get; set; }

        public DateTimeOffset To { get; set; }
    }
}
