using DogtrekkingCzShared.Entities;

namespace DogtrekkingCz.Interfaces.Actions.Entities;

public sealed record GetAllActionsResponse
{
    public IReadOnlyList<ActionDto> Actions { get; init; } = new List<ActionDto>();
}