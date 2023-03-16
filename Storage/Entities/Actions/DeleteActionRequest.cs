namespace Storage.Entities.Actions;

public sealed record DeleteActionRequest
{
    public required string Id { get; set; }
}