namespace PetsOnTrail.Interfaces.Actions.Entities.Rights
{
    public sealed record GetAllRightsRequest
    {
        public string UserId { get; set; }
    }
}
