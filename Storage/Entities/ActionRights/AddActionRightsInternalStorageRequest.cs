namespace Storage.Entities.ActionRights
{
    public sealed record AddActionRightsInternalStorageRequest
    {
        public Guid Id { get; init; } = Guid.Empty;

        public Guid UserId { get; init; } = Guid.Empty;

        public string ActionId { get; init; } = string.Empty;
    
        public IList<string> Roles { get; set; } = new List<string>();
    }
}
