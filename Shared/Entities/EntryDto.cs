namespace DogtrekkingCzShared.Entities;

public record EntryDto
{
    public string? Id { get; set; } = "";

    public string UserProfileId { get; set; } = "";
    
    public string CompetitorId { get; set; } = "";

    public string Name { get; set; } = "";

    public string Surname { get; set; } = "";

    public string Phone { get; set; } = "";

    public string Email { get; set; } = "";

    public IList<DogDto> Dogs { get; set; } = new List<DogDto>();

    public IList<string> Notes { get; set; } = new List<string>();

    public string ActionId { get; set; } = "";

    public string RaceId { get; set; } = "";

    public string CategoryId { get; set; } = "";
    
    public DateTimeOffset Created { get; set; } = DateTimeOffset.Now;

    public record DogDto
    {
        public string? Id { get; set; }
        
        public string Name { get; set; } = string.Empty;

        public string Pedigree { get; set; } = string.Empty;

        public string Chip { get; set; } = string.Empty;

        public DateTimeOffset? Birthday { get; set; } = null;
    }
}