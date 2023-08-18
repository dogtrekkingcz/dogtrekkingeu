namespace SharedLib.Models;

public record ActionSettingsModel
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }

    public List<RaceDto> Races { get; set; } = new List<RaceDto>();

    public List<CategoryDto> Categories { get; set; } = new List<CategoryDto>();

    public sealed record RaceDto
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        
        public DateTimeOffset Start { get; set; }

        public RaceLimits Limits { get; set; } = new();
    }

    public sealed record CategoryDto
    {
        public Guid Id { get; set; }
        
        public Guid RaceId { get; set; }
        
        public string Name { get; set; }
    }

    public sealed record RaceLimits
    {
        public int MinimalAgeOfTheDogInDayes = 0;

        public int MinimalAgeOfRacerInDayes = 0;

        public bool WithDogs = true;
    }
}