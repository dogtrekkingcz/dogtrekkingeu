namespace Storage.Models;

public sealed record MigrationRecord : IRecord
{
    public string? Id { get; set; } = $"{DateTime.Now.ToString("yyyyMMdd_HHmmss")}_NotSpecified";
    
    public string Name { get; set; }
    
    public DateTimeOffset Created { get; set; } = DateTimeOffset.Now;
}