namespace PetsOnTrail.Interfaces.Actions.Entities.Rights
{
    public sealed record GetAllRightsRequest
    {
        public Guid UserId { get; set; }
    }
}
