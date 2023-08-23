namespace Storage.Entities.Migrations;

public sealed record CreateMigrationInternalStorageRequest
{
    public string? Id { get; set; }
    
    public string? UserId { get; set; }
    
    public string Name { get; set; }
    
    public DateTimeOffset Created { get; set; }
}