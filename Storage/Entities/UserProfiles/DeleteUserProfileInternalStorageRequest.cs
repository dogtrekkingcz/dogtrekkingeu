namespace Storage.Entities.UserProfiles;

public sealed record DeleteUserProfileInternalStorageRequest
{
    public Guid Id { get; init; } = Guid.Empty;
}