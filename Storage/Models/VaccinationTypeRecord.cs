namespace Storage.Models;

public sealed record VaccinationTypeRecord : IRecord
{
    public string Id { get; set; }

    public string UserId { get; set; }

    public string Name { get; init; }

    public string Description { get; init; }

    public string PetType { get; init; }
}
