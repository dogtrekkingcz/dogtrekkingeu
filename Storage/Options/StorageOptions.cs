namespace Storage.Interfaces.Options;

public sealed record StorageOptions
{
    public string MongoDbConnectionString { get; init; }
}