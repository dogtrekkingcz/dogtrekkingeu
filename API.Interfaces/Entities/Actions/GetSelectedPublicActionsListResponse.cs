namespace PetsOnTrail.Interfaces.Actions.Entities.Actions;

public sealed record GetSelectedPublicActionsListResponse
{
    public IEnumerable<ActionDto> Actions { get; set; } = new List<ActionDto>();

    public sealed record ActionDto
    {
        public Guid Id { get; set; }

        public ActionType Type { get; set; } = ActionType.Unspecified;

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string ContactMail { get; set; } = string.Empty;

        public TermDto Term { get; set; } = new();

        public AddressDto Address { get; set; } = new();

        public List<CheckpointDto> Checkpoints { get; set; } = new List<CheckpointDto>();

        public List<RaceDto> Races { get; set; } = new List<RaceDto>();

        public ActionSaleDto Sale { get; set; } = new();
    }

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

    public sealed record CheckpointDto
    {
        public Guid Id { get; set; } = default(Guid);

        public string Name { get; set; } = string.Empty;

        public LatLngDto Position { get; set; } = new();
    }

    public sealed record RaceDto
    {
        public Guid Id { get; set; } = default(Guid);

        public string Name { get; set; } = string.Empty;

        public double? Distance { get; set; } = 0.0;

        public double? Incline { get; set; } = 0.0;

        public DateTimeOffset EnteringFrom = DateTimeOffset.Now;

        public DateTimeOffset EnteringTo = DateTimeOffset.Now.AddYears(1);

        public int MaxNumberOfCompetitors = Int32.MaxValue;

        public DateTimeOffset Begin = DateTimeOffset.Now;

        public IList<CategoryDto> Categories { get; set; } = new List<CategoryDto>();

        public IList<PaymentDefinitionDto> Payments { get; set; } = new List<PaymentDefinitionDto>();

        public LimitsDto Limits { get; set; } = new();
    }

    public sealed record CategoryDto
    {
        public Guid Id { get; set; } = default(Guid);

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public IList<RacerDto> Racers { get; set; } = new List<RacerDto>();
    }

    public enum RaceState
    {
        NotValid = 0,
        NotStarted,
        Started,
        Finished,
        DidNotFinished,
        Disqualified
    }

    public record RacerDto
    {
        public Guid Id { get; set; } = Guid.Empty;

        public string CompetitorId { get; set; } = string.Empty;

        public string CheckpointData { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public List<PetDto> Pets { get; set; } = new List<PetDto>();

        public DateTimeOffset? Start { get; set; } = null;

        public DateTimeOffset? Finish { get; set; } = null;

        public RaceState State { get; set; } = RaceState.NotValid;
        
        public List<PassedCheckpointDto> PassedCheckpoints { get; set; } = new();
    }

    public sealed record PassedCheckpointDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    
        public DateTimeOffset Passed { get; set; } = DateTimeOffset.Now;

        public LatLngDto Position { get; set; } = new();
    }

    public record PetDto
    {
        public string? Id { get; set; }

        public string UserId { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Kennel { get; set; } = string.Empty;

        public string Pedigree { get; set; } = string.Empty;

        public string Chip { get; set; } = string.Empty;

        public DateTimeOffset? Birthday { get; set; } = null;

        public string UriToPhoto { get; set; } = string.Empty;
    }

    public sealed record PaymentDefinitionDto
    {
        public Guid Id { get; set; } = default(Guid);

        public string BankAccount { get; set; }

        public DateTimeOffset From { get; set; }

        public DateTimeOffset To { get; set; }

        public double Price { get; set; }

        public string Currency { get; set; } = "Kc";
    }

    public sealed record LimitsDto
    {
        public int MinimalAgeOfRacerInDayes { get; set; } = 0;

        public int MinimalAgeOfThePetInDayes { get; set; } = 0;

        public bool WithPets { get; set; } = true;
    }

    public sealed record TermDto
    {
        public DateTimeOffset From { get; set; } = DateTime.Now;

        public DateTimeOffset To { get; set; } = DateTime.Now.AddDays(3);
    }

    public sealed record AddressDto
    {
        public string Country { get; set; } = string.Empty;

        public string Region { get; set; } = string.Empty;

        public string ZipCode { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string Street { get; set; } = string.Empty;

        public LatLngDto Position { get; set; } = new();
    }

    public sealed record LatLngDto
    {
        public double Latitude { get; set; } = double.NaN;

        public double Longitude { get; set; } = double.NaN;
    }

    public sealed record ActionSaleDto
    {
        public List<ActionSaleItemDto> Items { get; set; } = new List<ActionSaleItemDto>();
    }

    public sealed record ActionSaleItemDto
    {
        public string? Id { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public double Price { get; set; } = 0.0;

        public string Currency { get; set; } = "Kč";

        public List<string> Variants { get; set; } = new List<string>();

        public List<string> Sizes { get; set; } = new List<string>();

        public List<string> Colors { get; set; } = new List<string>();
    }
}