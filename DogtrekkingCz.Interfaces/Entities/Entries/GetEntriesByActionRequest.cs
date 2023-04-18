namespace DogtrekkingCz.Interfaces.Actions.Entities.Entries;

public sealed record GetEntriesByActionRequest
{
    public string ActionId { get; set; }
}