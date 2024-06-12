namespace Storage.Models;

internal sealed record ActionRecord : BaseRecord, IRecord
{
    public Guid TypeId { get; set; } = Guid.Empty;
    public DateTimeOffset Created { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ContactMail { get; set; } = string.Empty;
    public TermDto Term { get; set; } = new();
    public AddressDto Address { get; set; } = new();
    public List<CheckpointDto> Checkpoints { get; set; } = new List<CheckpointDto>();    
    public List<RaceDto> Races { get; set; } = new List<RaceDto>();
    public ActionSaleDto Sale { get; set; } = new();

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
        public DateTimeOffset End = DateTimeOffset.Now.AddDays(10);
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

        public string Phone { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public List<PetDto> Pets { get; set; } = new List<PetDto>();

        public DateTimeOffset? Start { get; set; } = null;

        public DateTimeOffset? Finish { get; set; } = null;

        public RaceState State { get; set; } = RaceState.NotValid;

        public bool Accepted { get; set; } = false;
        
        public DateTimeOffset? AcceptedDate { get; set; }

        public bool Payed { get; set; } = false;
        
        public DateTimeOffset? PayedDate { get; set; }

        public List<PaymentDto> Payments { get; set; } = new();

        public List<NoteDto> Notes { get; set; } = new List<NoteDto>();
        
        public RequestedPaymentsDto RequestedPayments { get; set; } = new();

        public List<MerchandizeItemDto> Merchandize { get; set; } = new();

        public AddressDto Address { get; set; } = new();
        
        public List<PassedCheckpointDto> PassedCheckpoints { get; set; } = new();
    }
    
    public sealed record PassedCheckpointDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        
        public DateTimeOffset Passed { get; set; } = DateTimeOffset.Now;

        public LatLngDto Position { get; set; } = new();
    }
    
    public class NoteDto
    {
        public DateTimeOffset Time { get; set; } = DateTimeOffset.Now;

        public string Text { get; set; } = string.Empty;
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

        public DateTimeOffset? Decease { get; set; } = null;

        public string UriToPhoto { get; set; } = string.Empty;

        public string Contact { get; set; } = string.Empty;

        public List<VaccinationDto> Vaccinations { get; set; } = new List<VaccinationDto>
        {
            new VaccinationDto
            {
                Type = VaccinationType.Rabies
            }
        };
    }
    
    public sealed record VaccinationDto
    {
        public DateTimeOffset? Date { get; set; } = DateTimeOffset.Now;

        public DateTimeOffset? ValidUntil { get; set; } = DateTimeOffset.Now;

        public VaccinationType Type { get; set; } = VaccinationType.NotValid;

        public string UriToPhoto { get; set; } = string.Empty;

        public string Note { get; set; } = string.Empty;
    }

    public enum VaccinationType
    {
        NotValid = 0,
        Rabies = 1, // Vzteklina
        Psinka = 2,
        Parvoviroza = 3,
        HepatitidaContagiosaCanis = 4,
        Leptospiroza = 5,
        Parainfluenza = 6,
        LymskaBorelioza = 7,
        Babesioza = 8,
        PlisnoveInfekce = 9,
        Leishmanioza = 10
    }


    public sealed record RequestedPaymentsDto
    {
        public string VariableNumber { get; set; } = string.Empty;
        
        public double Sum => Items.Sum(item => item.Price);

        public List<RequestedPaymentItem> Items { get; set; } = new();
    }

    public sealed record RequestedPaymentItem
    {
        public string Name { get; set; } = string.Empty;

        public double Price { get; set; } = double.NaN;

        public string Currency { get; set; } = string.Empty;
    }

    public record PaymentDto
    {
        public DateTimeOffset Date { get; set; } = DateTimeOffset.Now;

        public double Amount { get; set; } = 0.0;

        public string Currency { get; set; } = "Kč";

        public string BankAccount { get; set; } = string.Empty;

        public string Note { get; set; } = string.Empty;
    }

    public record MerchandizeItemDto
    {
        public string? Id { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
            
        public double Price { get; set; } = 0.0;

        public string Currency { get; set; } = "Kč";

        public string Variant { get; set; } = string.Empty;
        
        public string Size { get; set; } = string.Empty;

        public string Color { get; set; } = string.Empty;

        public string Note { get; set; } = string.Empty;

        public int Count { get; set; } = 0;
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