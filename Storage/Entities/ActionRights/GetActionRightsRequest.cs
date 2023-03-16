namespace Storage.Entities.ActionRights
{
    public sealed record GetActionRightsRequest
    {
        public string UserId { get; set; }
    }
}
