namespace Storage.Entities.UserProfiles;

public sealed record DeleteUserProfileInternalStorageRequest
{
    public string Email { get; set; }
}