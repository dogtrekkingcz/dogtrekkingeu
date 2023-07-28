namespace Storage.Entities.Migrations;

public sealed record GetMigrationInternalStorageRequest
{
    public string Id { get; set; }
}