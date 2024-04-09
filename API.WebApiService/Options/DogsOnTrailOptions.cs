namespace API.WebApiService.Options;

public sealed record PetsOnTrailOptions
{
    public string MongoDbConnectionString { get; set; } = "";
}