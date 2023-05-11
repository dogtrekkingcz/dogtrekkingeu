using SharedCode.Entities;

namespace DogsOnTrail.Interfaces.Actions.Entities.Actions;

public sealed record GetAllActionsResponse
{
    public IList<ActionDto> Actions { get; init; } = new List<ActionDto>();
}