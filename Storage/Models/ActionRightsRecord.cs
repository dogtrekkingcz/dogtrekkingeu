namespace Storage.Models
{
    internal sealed record ActionRightsRecord : IRecord
    {
        public string? Id { get; set; } = Guid.Empty.ToString();

        public string UserId { get; set; } = string.Empty;

        public string ActionId { get; set; } = string.Empty;
        
        public IList<string> Roles { get; set; } = new List<string>();
    }
}
