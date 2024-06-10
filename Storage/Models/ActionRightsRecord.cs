namespace Storage.Models;

internal sealed record ActionRightsRecord : BaseRecord, IRecord
{
    public string ActionId { get; set; } = string.Empty;
    
    public IList<string> Roles { get; set; } = new List<string>();
}
