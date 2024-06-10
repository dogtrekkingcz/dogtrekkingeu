namespace Storage.Models;

internal sealed record PetRecord : BaseRecord, IRecord
{
    public string Name { get; set; } = string.Empty;

    public string Kennel { get; set; } = string.Empty;

    public string Pedigree { get; set; } = string.Empty;

    public string Chip { get; set; } = string.Empty;

    public DateTimeOffset? Birthday { get; set; } = null;

    public DateTimeOffset? Decease { get; set; } = null;

    public string UriToPhoto { get; set; } = string.Empty;

    public string Contact { get; set; } = string.Empty;

    public string PetType { get; set; } = string.Empty;

    public List<VaccinationDto> Vaccinations { get; set; } = new List<VaccinationDto>();

    public sealed record VaccinationDto
    {
        public DateTimeOffset? Date { get; set; } = DateTimeOffset.Now;

        public DateTimeOffset? ValidUntil { get; set; } = DateTimeOffset.Now;

        public string VaccinationType { get; set; } = string.Empty;

        public string UriToPhoto { get; set; } = string.Empty;

        public string Note { get; set; } = string.Empty;
    }
}
