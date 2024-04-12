namespace Storage.Models
{
    internal sealed record AuthorizationRoleRecord : IRecord
    {
        public string? Id { get; set; } = string.Empty;

        public string UserId { get; set; } = string.Empty;

        public RoleType Type { get; set; } = RoleType.None;

        public string Name { get; set; } = string.Empty;

        public IList<Constants.ActionType> Actions { get; set; } = new List<Constants.ActionType>();
            
        public enum RoleType
        {
            None = 0,
            User = 1,
            Owner = 2
        }
    }
}
