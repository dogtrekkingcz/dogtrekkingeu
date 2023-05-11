using SharedCode.Entities;

namespace Storage.Entities.Actions;

public sealed record GetAllActionsInternalStorageResponse
{
    public IReadOnlyList<ActionDto> Actions { get; init; } = new List<ActionDto>();
}