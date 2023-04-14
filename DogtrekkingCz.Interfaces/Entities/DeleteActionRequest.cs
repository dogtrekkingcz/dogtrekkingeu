namespace DogtrekkingCz.Interfaces.Actions.Entities;

public sealed record DeleteActionRequest
{
    public required string Id { get; set; }
}