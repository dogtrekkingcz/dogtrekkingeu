namespace Mails.Entities;

public record NewActionRegistrationEmailRequest
{
    public ActionDto Action { get; set; }
    
    public RaceDto Race { get; set; }
    
    public CategoryDto Category { get; set; }
    
    public RacerDto Racer { get; set; }
    
    
    public sealed record ActionDto
    {
        public string Name { get; set; }
        
        public string Term { get; set; }
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
}