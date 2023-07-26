namespace Storage.Entities.ActionRights
{
    public sealed record GetAllRightsInternalStorageRequest
    {
        public string UserId { get; set; }
    }
}
