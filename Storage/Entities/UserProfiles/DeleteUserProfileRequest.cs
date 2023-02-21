namespace DogtrekkingCz.Storage.Entities.UserProfiles;

public sealed record DeleteUserProfileRequest
{
    public string Email { get; set; }
}