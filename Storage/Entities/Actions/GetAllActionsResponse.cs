using DogtrekkingCz.Shared.Entities;

namespace Storage.Entities.Actions;

public sealed record GetAllActionsResponse
{
    public IReadOnlyList<ActionDto> Actions { get; init; } = new List<ActionDto>();
}