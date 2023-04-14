namespace DogtrekkingCz.Interfaces.Actions.Entities;

public sealed record GetActionRequest
{
    public Guid Id { get; set; }
}