namespace Storage.Entities.ActionRights
{
    public sealed record AddActionRightsInternalStorageRequest
    {
        public string? Id { get; set; } = Guid.Empty.ToString();

        public string UserId { get; set; } = string.Empty;

        public string ActionId { get; set; } = string.Empty;
    
        public IList<string> Roles { get; set; } = new List<string>();

        public enum RoleType
        {
            None = 0,
            User = 1,
            Owner = 2
        }
    }
}
