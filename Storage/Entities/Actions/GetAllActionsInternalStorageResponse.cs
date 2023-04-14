using DogtrekkingCzShared.Entities;

namespace Storage.Entities.Actions;

public sealed record GetAllActionsInternalStorageResponse
{
    public IReadOnlyList<ActionDto> Actions { get; init; } = new List<ActionDto>();
}