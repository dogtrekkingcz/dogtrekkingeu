namespace SharedLib.Models;

public record PetModel
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

    public Guid PetType { get; set; } = Guid.Empty;

    public List<VaccinationDto> Vaccinations { get; set; } = new List<VaccinationDto>();

    public sealed record VaccinationDto
    {
        public DateTimeOffset? Date { get; set; } = DateTimeOffset.Now;

        public DateTimeOffset? ValidUntil { get; set; } = DateTimeOffset.Now;

        public Guid VaccinationType { get; set; } = Guid.Empty;

        public string UriToPhoto { get; set; } = string.Empty;

        public string Note { get; set; } = string.Empty;
    }
}