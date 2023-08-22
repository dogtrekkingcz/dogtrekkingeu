namespace DogsOnTrail.Interfaces.Actions.Entities.Actions;

public sealed record GetActionEntrySettingsResponse
{
    public Guid Id { get; set; }

    public ActionType Type { get; set; } = ActionType.Unspecified;
    
    public string Name { get; set; }

    public List<RaceDto> Races { get; set; } = new List<RaceDto>();

    public List<CategoryDto> Categories { get; set; } = new List<CategoryDto>();

    public enum ActionType
    {
        Unspecified = 0,
        Trip = 1,
        Dogtrekking = 2,
        RallyObedience = 3,
        Obedience = 4,
        Agility = 5,
        Mushing = 6,
        HorseMountainTrail = 7
    }
    
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