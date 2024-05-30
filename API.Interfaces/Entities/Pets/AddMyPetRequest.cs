namespace PetsOnTrail.Interfaces.Actions.Entities.Pets;

public sealed record AddMyPetRequest
{
    public Guid Id { get; init; }
    public Guid UserId { get; init; }
    public string Contact { get; init; }
    public string Name { get; init; }
    public string Kennel { get; init; }
    public string Pedigree { get; init; }
    public string Chip { get; init; }
    public DateTimeOffset? Birthday { get; init; }
    public DateTimeOffset? Decease { get; init; }
    public string UriToPhoto { get; init; }
    public Guid PetType { get; init; }
    public List<VaccinationDto> Vaccinations { get; init; } = new List<VaccinationDto>();

    public sealed record VaccinationDto
    {
        public DateTimeOffset? Date { get; init; }
        public DateTimeOffset? ValidUntil { get; init; }
        public Guid VaccinationType { get; init; }
        public string Note { get; init; }
        public string UriToPhoto { get; init; }
    }
}


