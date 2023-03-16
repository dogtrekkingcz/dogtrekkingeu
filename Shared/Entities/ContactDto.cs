namespace DogtrekkingCz.Shared.Entities
{
    public sealed record ContactDto
    {
        public string PhoneNumber { get; set; }

        public string EmailAddress { get; set; }
    }
}
