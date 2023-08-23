namespace Storage.Models
{
    internal sealed record AuthorizationRoleRecord : IRecord
    {
        public string? Id { get; set; } = Guid.Empty.ToString();

        public string? UserId { get; set; } = null;

        public string Name { get; set; } = string.Empty;

        public IList<string> Actions { get; set; } = new List<string>();
    }
}
