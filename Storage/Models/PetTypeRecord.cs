namespace Storage.Models;

internal sealed record PetTypeRecord : BaseRecord, IRecord
{
    public string Name { get; init; }

    public string Description { get; init; }
}
