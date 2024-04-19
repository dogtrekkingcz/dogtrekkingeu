namespace PetsOnTrailApp.Components.Results.Results;

public sealed record RacesModel
{
    public List<RaceDto> Races { get; set; } = new();

    public sealed record RaceDto
    {

    }
}