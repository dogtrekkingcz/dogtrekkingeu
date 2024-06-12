namespace Storage.Entities.ActionRights
{
    public sealed record AddActionRightsInternalStorageRequest
    {
        public Guid Id { get; init; } = Guid.Empty;

        public Guid UserId { get; init; } = Guid.Empty;

        public Guid ActionId { get; init; } = Guid.Empty;
    
        public IList<Guid> Roles { get; set; } = new List<Guid>();
    }
}
