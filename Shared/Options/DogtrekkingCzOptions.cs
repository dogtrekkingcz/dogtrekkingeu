namespace SharedCode.Options
{
    public sealed record DogsOnTrailOptions
    {
        public string MongoDbConnectionString { get; set; } = "";
    }
}
