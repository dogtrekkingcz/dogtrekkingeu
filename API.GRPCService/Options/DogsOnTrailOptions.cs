namespace API.GRPCService.Options;

public sealed record PetsOnTrailOptions
{
    public string MongoDbConnectionString { get; set; } = "";

    public string BackupPath { get; set; } = "";
}