using System.Text.Json.Serialization;

namespace PetsOnTrailApp.DataStorage.Repositories.ActivityRepository;

public sealed record GetActivityByUserIdAndActivityIdResponseModel
{
    public Guid Id { get; init; }
    public Guid ActionId { get; init; } = Guid.Empty;
    public Guid RaceId { get; init; } = Guid.Empty;
    public Guid CategoryId { get; init; } = Guid.Empty;
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public DateTime Start { get; init; }
    public DateTime End { get; init; }
    public bool IsPublic { get; init; }
    public IList<PositionDto> Positions { get; init; } = new List<PositionDto>(0);
    public IList<PetDto> Pets { get; init; } = new List<PetDto>(0);

    public sealed record PositionDto
    {
        [JsonPropertyName("id")]
        public Guid Id { get; init; } = Guid.Empty;

        [JsonPropertyName("_t")]
        public DateTime Time { get; init; }

        [JsonPropertyName("la")]
        public double Latitude { get; init; }

        [JsonPropertyName("lo")]
        public double Longitude { get; init; }

        [JsonPropertyName("alt")]
        public double Altitude { get; init; }

        [JsonPropertyName("acc")]
        public double Accuracy { get; init; }

        [JsonPropertyName("_c")]
        public double Course { get; init; }

        [JsonPropertyName("_n")]
        public string Note { get; init; }
        // public IList<string> PhotoUris { get; init; } = new List<string>(0);
    }

    public sealed record PetDto
    {
        public Guid Id { get; init; } = Guid.Empty;
        public string Chip { get; init; }
        public string Name { get; init; }
        public string Breed { get; init; }
        public string Color { get; init; }
        public string Kennel { get; init; }
        public DateTime BirthDate { get; init; }
    }
}