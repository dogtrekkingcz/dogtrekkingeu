namespace PetsOnTrail.Interfaces.Actions.Entities.Actions;

public sealed record GetActionEntrySettingsRequest
{
    public Guid ActionId { get; set; }
}