namespace Storage.Entities.UserProfiles;

public sealed record GetUserProfileInternalStorageRequest
{
    public required Guid UserId { get; set; }
}