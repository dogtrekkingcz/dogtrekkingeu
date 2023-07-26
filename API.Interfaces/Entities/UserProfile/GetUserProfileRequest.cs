namespace DogsOnTrail.Interfaces.Actions.Entities.UserProfile
{
    public sealed record GetUserProfileRequest
    {
        public string UserId { get; set; }
    }
}
