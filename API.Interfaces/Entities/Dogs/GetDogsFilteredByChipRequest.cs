namespace DogsOnTrail.Interfaces.Actions.Entities.Dogs;

public record GetDogsFilteredByChipRequest
{
    public string Chip { get; set; } = string.Empty;
}