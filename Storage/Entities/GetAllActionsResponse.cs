using DogtrekkingCz.Storage.Models;

namespace Storage.Interfaces.Entities;

public sealed record GetAllActionsResponse
{
    public IReadOnlyList<ActionRecord> Actions { get; init; }
}