namespace PetsOnTrail.Interfaces.Actions.Entities.Actions;

public record GetRacesForActionRequest
{
    public Guid ActionId { get; set; }
}