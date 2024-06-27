namespace Storage.Models;

internal sealed record ActionRightsRecord : BaseRecord, IRecord
{
    public Guid ActionId { get; set; } = Guid.Empty;
    
    public List<Guid> Roles { get; set; } = new List<Guid>();
}
