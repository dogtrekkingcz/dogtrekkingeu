namespace Storage.Models;

internal sealed record VaccinationTypeRecord : BaseRecord, IRecord
{
    public string Name { get; init; }

    public string Description { get; init; }

    public string PetType { get; init; }
}
