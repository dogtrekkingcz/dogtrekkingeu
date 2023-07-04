using SharedCode.Entities;

namespace DogsOnTrail.Interfaces.Actions.Entities.Actions;

public sealed record GetSelectedActionsResponse
{
    public IReadOnlyList<ActionDto> Actions { get; init; } = new List<ActionDto>();
}