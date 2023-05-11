namespace SharedCode.Entities
{
    public record AuthorizationRoleDto
    {
        public enum RoleType
        {
            None = 0,
            User = 1,
            Owner = 2
        }

        public enum ActionType
        {
            None = 0,
            Read = 1,
            Update = 2,
            Delete = 3
        }

        public string? Id { get; set; } = string.Empty;

        public RoleType Type { get; set; } = RoleType.None;

        public string Name { get; set; } = string.Empty;

        public IList<ActionType> Actions { get; set; } = new List<ActionType>();
    }
}
