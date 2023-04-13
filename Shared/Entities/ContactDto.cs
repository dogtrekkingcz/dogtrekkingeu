namespace DogtrekkingCzShared.Entities
{
    public sealed record ContactDto
    {
        public string PhoneNumber { get; set; } = string.Empty;

        public string EmailAddress { get; set; } = string.Empty;
    }
}
