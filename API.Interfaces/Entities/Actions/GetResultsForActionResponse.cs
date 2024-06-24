namespace PetsOnTrail.Interfaces.Actions.Entities.Actions;

public sealed record GetResultsForActionResponse
{ 
    public List<RaceResultsDto> Races { get; set; } = new();

    public sealed record RaceResultsDto
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        
        public double Distance { get; set; }
        
        public double Incline { get; set; }

        public List<CategoryResultsDto> Categories { get; set; } = new();
    }

    public sealed record CategoryResultsDto
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }

        public List<RacerResultDto> Racers { get; set; } = new();
    }

    public enum RaceState
    {
        NotSpecified = 0,
        NotStarted = 1,
        Started = 2,
        Finished = 3,
        DidNotFinished = 4,
        Disqualified = 5
    };

    public sealed record RacerResultDto
    {
        public Guid Id { get; set; }

        public Guid CompetitorId { get; set; } = Guid.Empty;
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public DateTimeOffset? Start { get; set; }
        
        public DateTimeOffset? Finish { get; set; }
        
        public RaceState State { get; set; }

        public List<PetDto> Pets { get; set; } = new();

        public List<PassedCheckpointDto> PassedCheckpoints { get; set; } = new();
    }

    public sealed record PassedCheckpointDto
    {
        public Guid Id { get; set; }
        
        public DateTimeOffset Passed { get; set; }

        public LatLngDto Position { get; set; } = new();
    }

    public sealed record LatLngDto
    {
        public double Latitude { get; set; } = double.NaN;
        
        public double Longitude { get; set; } = Double.NaN;
    }

    public sealed record PetDto
    {
        public Guid Id { get; set; } = Guid.Empty;
        public Guid UserId { get; set; } = Guid.Empty;
        public string Name { get; set; } = string.Empty;
        public string Breed { get; set; } = string.Empty;
        public Guid PetType { get; set; } = Guid.Empty;
        public string Kennel { get; set; } = string.Empty;
        public string Pedigree { get; set; } = string.Empty;
        public string Chip { get; set; } = string.Empty;
        public DateTimeOffset? Birthday { get; set; } = null;
        public string UriToPhoto { get; set; } = string.Empty;
        public string Contact { get; set; } = string.Empty;
    }
}
