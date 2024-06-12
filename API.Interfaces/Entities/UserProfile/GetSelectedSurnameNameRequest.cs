namespace PetsOnTrail.Interfaces.Actions.Entities.UserProfile
{
    public sealed record GetSelectedSurnameNameRequest
    {
        public List<Guid> Ids { get; set; } = new();
    }
}
