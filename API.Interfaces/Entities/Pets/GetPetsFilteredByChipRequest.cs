namespace PetsOnTrail.Interfaces.Actions.Entities.Pets;

public record GetPetsFilteredByChipRequest
{
    public string Chip { get; set; } = string.Empty;
}