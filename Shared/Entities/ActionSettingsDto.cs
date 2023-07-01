namespace SharedCode.Entities;

public record ActionSettingsDto
{
    public string Id { get; set; }
    
    public string Name { get; set; }

    public List<RaceDto> Races { get; set; } = new List<RaceDto>();

    public List<CategoryDto> Categories { get; set; } = new List<CategoryDto>();

    public sealed record RaceDto
    {
        public string Id { get; set; }
        
        public string Name { get; set; }
        
        public DateTimeOffset Start { get; set; }

        public RaceLimits Limits { get; set; } = new();
    }

    public sealed record CategoryDto
    {
        public string Id { get; set; }
        
        public string RaceId { get; set; }
        
        public string Name { get; set; }
    }

    public sealed record RaceLimits
    {
        public int MinimalAgeOfTheDogInDayes = 0;

        public int MinimalAgeOfRacerInDayes = 0;
    }
}