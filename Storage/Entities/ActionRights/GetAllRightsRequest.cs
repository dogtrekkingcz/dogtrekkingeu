namespace Storage.Entities.ActionRights
{
    public sealed record GetAllRightsRequest
    {
        public string UserId { get; set; }
    }
}
