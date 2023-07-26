namespace Storage.Entities.ActionRights
{
    public sealed record GetAllRightsInternalStorageResponse
    {
        public IReadOnlyList<ActionRightsDto> Rights { get; init; }
        
        public sealed record ActionRightsDto
        {
            public string? Id { get; set; } = Guid.Empty.ToString();

            public string UserId { get; set; } = string.Empty;

            public string ActionId { get; set; } = string.Empty;
        
            public IList<string> Roles { get; set; } = new List<string>();
        }
    }
}
