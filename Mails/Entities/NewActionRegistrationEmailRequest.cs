namespace Mails.Entities;

public record NewActionRegistrationEmailRequest
{
    public ActionDto Action { get; set; } = new();

    public RaceDto Race { get; set; } = new();

    public CategoryDto Category { get; set; } = new();

    public RacerDto Racer { get; set; } = new();

    public Dictionary<TermDto, PaymentDto> Payments { get; set; } = new();
    
    
    public sealed record ActionDto
    {
        public string Name { get; set; }
        
        public string Email { get; set; }
        
        public TermDto Term { get; set; }
    }

    public sealed record RaceDto
    {
        public string Name { get; set; }
    }

    public sealed record CategoryDto
    {
        public string Name { get; set; }
    }
    
    public sealed record RacerDto
    {
        public string Name { get; set; }
        
        public string Surname { get; set; }
        
        public string Email { get; set; }

        public List<DogDto> Dogs { get; set; } = new();
    }

    public sealed record DogDto
    {
        public string Chip { get; set; }
        
        public string Pedigree { get; set; }
        
        public DateTimeOffset? Birthday { get; set; }
        
        public string Name { get; set; }

        public List<VaccinationDto> Vaccinations { get; set; } = new();
    }

    public sealed record VaccinationDto
    {
        public string Type { get; set; }
        
        public DateTimeOffset? Date { get; set; }
    }

    public sealed record TermDto
    {
        public DateTimeOffset From { get; set; }
        
        public DateTimeOffset To { get; set; }
    }

    public sealed record PaymentDto
    {
        public string BankAccount { get; set; }
        
        public DateTimeOffset From { get; set; }
        
        public DateTimeOffset To { get; set; }
        
        public double Price { get; set; }
        
        public string Currency { get; set; }
    }
}