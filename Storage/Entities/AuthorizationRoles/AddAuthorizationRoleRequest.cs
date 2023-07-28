namespace Storage.Entities.AuthorizationRoles
{
    public record AddAuthorizationRoleRequest
    {
        public string? Id { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public IList<string> Actions { get; set; } = new List<string>();
    }
}
