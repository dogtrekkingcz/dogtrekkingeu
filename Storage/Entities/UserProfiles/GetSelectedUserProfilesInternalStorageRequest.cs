namespace Storage.Entities.UserProfiles;

public sealed record GetSelectedUserProfilesInternalStorageRequest
{
    public List<string> Ids { get; set; } = new();
}