namespace DogtrekkingCz.Entries.Interface.Entities;

public sealed record DeleteEntryRequest
{
    public string Id { get; set; }
}