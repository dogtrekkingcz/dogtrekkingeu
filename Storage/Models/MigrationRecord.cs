namespace Storage.Models;

internal sealed record MigrationRecord : BaseRecord, IRecord
{
    public string Name { get; set; } = $"{DateTime.Now.ToString("yyyyMMdd_HHmmss")}_NotSpecified";
    
    public DateTimeOffset Created { get; set; } = DateTimeOffset.Now;
}