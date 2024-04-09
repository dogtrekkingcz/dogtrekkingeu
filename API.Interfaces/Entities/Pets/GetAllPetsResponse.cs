namespace PetsOnTrail.Interfaces.Actions.Entities.Pets;

public sealed record GetAllPetsResponse
{
    public IList<PetDto> Pets { get; set; } = new List<PetDto>();

    public sealed record PetDto
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

        public List<VaccinationDto> Vaccinations { get; set; } = new List<VaccinationDto>();
        
        public PetType Type { get; set; } = PetType.PetType_Unspecified;

        public List<LostPetRecordDto> Losts { get; set; } = new List<LostPetRecordDto>();
    }
    
    public sealed record LostPetRecordDto
    {
        public DateTimeOffset Lost { get; set; }
        public DateTimeOffset? Found { get; set; }
        public string ExpectedArea { get; set; }
        public List<PetWasSeenDto> WasSeen { get; set; } = new List<PetWasSeenDto>();
    }

    public sealed record PetWasSeenDto
    {
        public DateTimeOffset Seen { get; set; }
        public string Area { get; set; }
    }
        
    public enum PetType 
    {
        PetType_Unspecified = 0,
        Dog = 1,
        Horse = 2,
        Cat = 3,
        Rabbit = 4
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
}