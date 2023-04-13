namespace Storage.Entities.UserProfiles;

public sealed record GetUserProfileRequest
{
    public required string Email { get; set; }
}