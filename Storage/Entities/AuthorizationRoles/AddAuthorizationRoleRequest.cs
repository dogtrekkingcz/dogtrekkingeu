namespace Storage.Entities.AuthorizationRoles
{
    public record AddAuthorizationRoleRequest
    {
        public Guid Id { get; init; } = Guid.Empty;

        public string UserId { get; init; } = string.Empty;

        public RoleType Type { get; init; } = RoleType.None;

        public string Name { get; init; } = string.Empty;

        public IList<Constants.ActionType> Actions { get; init; } = new List<Constants.ActionType>();

        public enum RoleType
        {
            None = 0,
            User = 1,
            Owner = 2
        }
    }
}
