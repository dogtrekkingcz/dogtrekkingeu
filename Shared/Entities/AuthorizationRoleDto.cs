namespace DogtrekkingCzShared.Entities
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

        public RoleType Id { get; set; }

        public string Name { get; set; }

        public IList<ActionType> Actions { get; set; } = new List<ActionType>();
    }
}
