namespace Storage.Models
{
    internal sealed record AuthorizationRoleRecord : IRecord
    {
        public string? Id { get; set; } = Guid.Empty.ToString();

        public string Name { get; set; } = string.Empty;

        public string UserId { get; set; } = string.Empty;

        public string ActionId { get; set; } = string.Empty;
        
        public RightsType Rights { get; set; }

        public IList<ActionType> Actions { get; set; } = new List<ActionType>();

        public enum RightsType
        {
            None = 0,
            View = 1,
            Edit = 2,
            Delete = 3,
            Admin = 4
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
