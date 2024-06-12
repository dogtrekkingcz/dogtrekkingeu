namespace Storage.Entities.ActionRights
{
    public sealed record GetAllRightsInternalStorageResponse
    {
        public IReadOnlyList<ActionRightsDto> Rights { get; init; }
        
        public sealed record ActionRightsDto
        {
            public Guid Id { get; set; } = Guid.Empty;

            public Guid UserId { get; set; } = Guid.Empty;

            public Guid ActionId { get; set; } = Guid.Empty;
        
            public IList<Guid> Roles { get; set; } = new List<Guid>();
        }
    }
}
