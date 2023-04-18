using DogtrekkingCzShared.Entities;

namespace DogtrekkingCz.Interfaces.Actions.Entities.Actions;

public sealed record GetAllActionsResponse
{
    public IList<ActionDto> Actions { get; init; } = new List<ActionDto>();
}