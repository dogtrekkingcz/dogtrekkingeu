namespace DogtrekkingCz.Entries.Interface.Entities;

public sealed record GetEntriesByActionRequest
{
    public string ActionId { get; set; }
}