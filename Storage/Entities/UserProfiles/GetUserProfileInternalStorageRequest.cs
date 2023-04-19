namespace Storage.Entities.UserProfiles;

public sealed record GetUserProfileInternalStorageRequest
{
    public required string UserId { get; set; }
}