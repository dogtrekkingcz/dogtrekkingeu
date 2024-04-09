namespace PetsOnTrail.Interfaces.Actions.Entities.Actions
{
    public sealed record GetActionDetailRequest
    {
        public Guid Id { get; set; }
    }
}
