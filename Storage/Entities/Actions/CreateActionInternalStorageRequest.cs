namespace Storage.Entities.Actions;

public sealed record CreateActionInternalStorageRequest
{
    public Guid Id { get; init; } = Guid.NewGuid();
    
    public Guid UserId { get; init; } = Guid.Empty;
    
    public DateTimeOffset Created { get; init; }
    
    public Guid TypeId { get; init; } = Guid.Empty;

    public string Name { get; init; } = string.Empty;

    public string Description { get; init; } = string.Empty;

    public string ContactMail { get; init; } = string.Empty;

    public List<Guid> ResultsCanEdit { get; set; } = new List<Guid> { Constants.Roles.InternalUser.GUID };

    public List<Guid> CompetitorsCanEdit { get; set; } = new List<Guid> { Constants.Roles.InternalUser.GUID };

    public List<Guid> ActionCanEdit { get; set; } = new List<Guid> { Constants.Roles.InternalUser.GUID };

    public string Www { get; init; } = string.Empty;

    public TermDto Term { get; init; } = new();

    public AddressDto Address { get; init; } = new();

    public List<RaceDto> Races { get; init; } = new List<RaceDto>();

    public ActionSaleDto Sale { get; init; } = new();
    
    public sealed record RaceDto
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public string Name { get; init; } = string.Empty;
        
        public double? Distance { get; init; } = 0.0;
        
        public double? Incline { get; init; } = 0.0;

        public DateTimeOffset EnteringFrom = DateTimeOffset.Now;
        
        public DateTimeOffset EnteringTo = DateTimeOffset.Now.AddYears(1);
        
        public int MaxNumberOfCompetitors = Int32.MaxValue;
        
        public DateTimeOffset Begin = DateTimeOffset.Now;
        public DateTimeOffset End = DateTimeOffset.Now.AddDays(10);
        
        public IList<CategoryDto> Categories { get; init; } = new List<CategoryDto>();

        public IList<PaymentDefinitionDto> Payments { get; init; } = new List<PaymentDefinitionDto>();

        public LimitsDto Limits { get; init; } = new();
        public List<CheckpointDto> Checkpoints { get; init; } = new List<CheckpointDto>();
    }

    public sealed record CheckpointDto
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public string Name { get; init; } = string.Empty;
        public LatLngDto Position { get; init; } = new();
    }

    public sealed record CategoryDto
    {
        public Guid Id { get; init; } = Guid.NewGuid();

        public string Name { get; init; } = string.Empty;

        public string Description { get; init; } = string.Empty;

        public IList<RacerDto> Racers { get; init; } = new List<RacerDto>();
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
        public Guid Id { get; init; } = Guid.NewGuid();
        
        public Guid CompetitorId { get; init; } = Guid.Empty;
        
        public string CheckpointData { get; init; } = string.Empty;

        public string FirstName { get; init; } = string.Empty;

        public string LastName { get; init; } = string.Empty;

        public string Phone { get; init; } = string.Empty;

        public string Email { get; init; } = string.Empty;

        public List<PetDto> Pets { get; init; } = new List<PetDto>();

        public DateTimeOffset? Start { get; init; } = null;

        public DateTimeOffset? Finish { get; init; } = null;

        public RaceState State { get; init; } = RaceState.NotValid;

        public bool Accepted { get; init; } = false;

        public bool Payed { get; init; } = false;

        public List<PaymentDto> Payments { get; init; } = new();

        public List<NoteDto> Notes { get; init; } = new List<NoteDto>();
        
        public RequestedPaymentsDto RequestedPayments { get; init; } = new();

        public List<MerchandizeItemDto> Merchandize { get; init; } = new();

        public AddressDto Address { get; init; } = new();
        
        public List<PassedCheckpointDto> PassedCheckpoints { get; init; } = new();
    }
    
    public sealed record PassedCheckpointDto
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        
        public DateTimeOffset Passed { get; init; } = DateTimeOffset.Now;

        public LatLngDto Position { get; init; } = new();
    }
    
    public class NoteDto
    {
        public DateTimeOffset Time { get; init; } = DateTimeOffset.Now;

        public string Text { get; init; } = string.Empty;
    }

    public record PetDto
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

    public sealed record RequestedPaymentsDto
    {
        public string VariableNumber { get; init; } = string.Empty;
        
        public double Sum => Items.Sum(item => item.Price);

        public List<RequestedPaymentItem> Items { get; init; } = new();
    }

    public sealed record RequestedPaymentItem
    {
        public string Name { get; init; }
        
        public double Price { get; init; }
        
        public string Currency { get; init; }
    }

    public record PaymentDto
    {
        public DateTimeOffset Date { get; init; } = DateTimeOffset.Now;

        public double Amount { get; init; } = 0.0;

        public string Currency { get; init; } = "Kč";

        public string BankAccount { get; init; } = string.Empty;

        public string Note { get; init; } = string.Empty;
    }

    public record MerchandizeItemDto
    {
        public string? Id { get; init; } = string.Empty;

        public string Name { get; init; } = string.Empty;

        public string Description { get; init; } = string.Empty;
            
        public double Price { get; init; } = 0.0;

        public string Currency { get; init; } = "Kč";

        public string Variant { get; init; } = string.Empty;
        
        public string Size { get; init; } = string.Empty;

        public string Color { get; init; } = string.Empty;

        public string Note { get; init; } = string.Empty;

        public int Count { get; init; } = 0;
    }
    
    public sealed record PaymentDefinitionDto
    {
        public Guid Id { get; init; } = default(Guid);
            
        public string BankAccount { get; init; }
            
        public DateTimeOffset From { get; init; }
            
        public DateTimeOffset To { get; init; }
            
        public double Price { get; init; }

        public string Currency { get; init; } = "Kc";
    }
    
    public sealed record LimitsDto
    {
        public int MinimalAgeOfRacerInDayes { get; init; } = 0;
            
        public int MinimalAgeOfThePetInDayes { get; init; } = 0;

        public bool WithPets { get; init; } = true;
    }
    
    public sealed record TermDto
    {
        public DateTimeOffset From { get; init; } = DateTime.Now;

        public DateTimeOffset To { get; init; } = DateTime.Now.AddDays(3);
    }
    
    public sealed record AddressDto
    {
        public string Country { get; init; } = string.Empty;

        public string Region { get; init; } = string.Empty;

        public string ZipCode { get; init; } = string.Empty;

        public string City { get; init; } = string.Empty;

        public string Street { get; init; } = string.Empty;

        public LatLngDto Position { get; init; } = new();
    }
    
    public sealed record LatLngDto
    {
        public double Latitude { get; init; } = 0.0;

        public double Longitude { get; init; } = 0.0;
    }
    
    public sealed record ActionSaleDto
    {
        public List<ActionSaleItemDto> Items { get; init; } = new List<ActionSaleItemDto>();
    }

    public sealed record ActionSaleItemDto
    {
        public string? Id { get; init; } = string.Empty;

        public string Name { get; init; } = string.Empty;

        public string Description { get; init; } = string.Empty;
            
        public double Price { get; init; } = 0.0;

        public string Currency { get; init; } = "Kč";

        public List<string> Variants { get; init; } = new List<string>();

        public List<string> Sizes { get; init; } = new List<string>();

        public List<string> Colors { get; init; } = new List<string>();
    }
}