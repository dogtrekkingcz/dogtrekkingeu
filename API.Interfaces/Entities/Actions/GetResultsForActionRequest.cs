namespace DogsOnTrail.Interfaces.Actions.Entities.Actions;

public record GetResultsForActionRequest
{
    public Guid ActionId { get; set; }
}