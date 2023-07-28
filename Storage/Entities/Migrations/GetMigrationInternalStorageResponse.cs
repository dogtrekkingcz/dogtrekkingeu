namespace Storage.Entities.Migrations;

public sealed record GetMigrationInternalStorageResponse
{
    public string? Id { get; set; }
    
    public string Name { get; set; }
    
    public DateTimeOffset Created { get; set; }
}