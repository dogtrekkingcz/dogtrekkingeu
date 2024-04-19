namespace PetsOnTrailApp.Models;

public sealed record RacesModel : BaseSynchronizedModel
{
    public Guid ActionId { get; set; }

    public List<RaceDto> Races { get; set; } = new();

    public sealed record RaceDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime Begin { get; set; }

        public DateTime End { get; set; }

        public double Distance { get; set; }

        public double Incline { get; set; }
    }
}
