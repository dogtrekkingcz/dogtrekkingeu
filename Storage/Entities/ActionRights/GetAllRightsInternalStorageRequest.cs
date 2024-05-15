namespace Storage.Entities.ActionRights
{
    public sealed record GetAllRightsInternalStorageRequest
    {
        public Guid UserId { get; set; }
    }
}
