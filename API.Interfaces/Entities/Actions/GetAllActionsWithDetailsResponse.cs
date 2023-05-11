using SharedCode.Entities;

namespace DogsOnTrail.Interfaces.Actions.Entities.Actions;

public sealed record GetAllActionsWithDetailsResponse
{
    public IReadOnlyList<ActionDto> Actions { get; init; } = new List<ActionDto>();
}