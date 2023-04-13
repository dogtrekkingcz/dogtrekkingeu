namespace Storage.Options;

public sealed record StorageOptions
{
    public string MongoDbConnectionString { get; init; }
}