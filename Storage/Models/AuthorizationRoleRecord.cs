namespace Storage.Models
{
    internal sealed record AuthorizationRoleRecord : IRecord
    {
        public string? Id { get; set; } = Guid.Empty.ToString();

        public string Name { get; set; } = string.Empty;

        public IList<string> Actions { get; set; } = new List<string>();
    }
}
