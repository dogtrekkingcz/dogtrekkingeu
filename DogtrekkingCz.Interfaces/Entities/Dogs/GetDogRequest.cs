namespace DogtrekkingCz.Interfaces.Actions.Entities.Dogs;

public record GetDogRequest
{
    public string Chip { get; set; } = string.Empty;
}