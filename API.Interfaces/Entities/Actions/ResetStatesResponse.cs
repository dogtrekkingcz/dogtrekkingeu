namespace PetsOnTrail.Interfaces.Actions.Entities.Actions;

public sealed record ResetStatesResponse
{
    public string State { get; init; } = string.Empty;
}
