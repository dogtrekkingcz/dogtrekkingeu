namespace Storage.Entities.AuthorizationRoles
{
    public sealed record GetAllAuthorizationRolesResponse
    {
        public List<AuthorizationRoleDto> AuthorizationRoles { get; init; } = new List<AuthorizationRoleDto>();
        
        public record AuthorizationRoleDto
        {
            public Guid? Id { get; set; } = Guid.Empty;

            public Guid UserId { get; set; } = Guid.Empty;

            public RoleType Type { get; set; } = RoleType.None;

            public string Name { get; set; } = string.Empty;

            public IList<ActionType> Actions { get; set; } = new List<ActionType>();
        }

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
    }
}
