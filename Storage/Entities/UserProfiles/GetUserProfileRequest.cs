namespace Storage.Entities.UserProfiles;

public sealed record GetUserProfileRequest
{
    public required string UserId { get; set; }
}