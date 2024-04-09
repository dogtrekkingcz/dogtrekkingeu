namespace PetsOnTrail.Interfaces.Actions.Entities.UserProfile
{
    public sealed record GetSelectedSurnameNameRequest
    {
        public List<string> Ids { get; set; } = new List<string>();
    }
}
