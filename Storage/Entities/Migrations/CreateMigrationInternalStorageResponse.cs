namespace Storage.Entities.Migrations;

public sealed record CreateMigrationInternalStorageResponse
{
    public Guid Id { get; set; } = Guid.Empty;
}