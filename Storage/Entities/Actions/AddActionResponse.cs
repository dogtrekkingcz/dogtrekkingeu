using static Storage.Entities.Actions.AddActionRequest;

namespace Storage.Entities.Actions;

public sealed record AddActionResponse
{
    public string Id { get; set; } = string.Empty;
}