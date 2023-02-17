namespace Storage.Interfaces.Entities;

public sealed record GetAllActionsRequest
{
    public int? Year { get; init; }
}