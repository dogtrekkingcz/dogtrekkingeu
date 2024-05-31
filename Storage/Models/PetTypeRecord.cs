namespace Storage.Models;

public sealed record PetTypeRecord : IRecord
{
    public string Id { get; set; }

    public string UserId { get; set; }

    public string Name { get; init; }

    public string Description { get; init; }
}
