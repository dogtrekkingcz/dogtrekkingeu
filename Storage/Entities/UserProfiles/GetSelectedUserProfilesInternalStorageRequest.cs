namespace Storage.Entities.UserProfiles;

public sealed record GetSelectedUserProfilesInternalStorageRequest
{
    public List<Guid> Ids { get; set; } = new();
}