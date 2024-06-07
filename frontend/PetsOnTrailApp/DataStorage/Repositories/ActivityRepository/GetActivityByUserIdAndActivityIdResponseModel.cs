using System.Text.Json.Serialization;

namespace PetsOnTrailApp.DataStorage.Repositories.ActivityRepository;

public sealed record GetActivityByUserIdAndActivityIdResponseModel
{
    public Guid Id { get; init; }
    public Guid ActionId { get; init; } = Guid.Empty;
    public Guid RaceId { get; init; } = Guid.Empty;
    public Guid CategoryId { get; init; } = Guid.Empty;
    public Guid TypeId { get; init; } = Guid.Empty;
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public DateTimeOffset? Start { get; init; } = null;
    public DateTimeOffset? End { get; init; } = null;
    public bool IsPublic { get; init; }
    public IList<PositionDto> Positions { get; init; } = new List<PositionDto>(0);
    public IList<PetDto> Pets { get; init; } = new List<PetDto>(0);

    public sealed record PositionDto
    {
        [JsonPropertyName("id")]
        public Guid Id { get; init; } = Guid.Empty;

        [JsonPropertyName("_t")]
        public DateTimeOffset? Time { get; init; } = null;

        [JsonPropertyName("la")]
        public double Latitude { get; init; }

        [JsonPropertyName("lo")]
        public double Longitude { get; init; }

        [JsonPropertyName("alt")]
        public double Altitude { get; init; }

        [JsonPropertyName("acc")]
        public double Accuracy { get; init; }

        [JsonPropertyName("_n")]
        public string Note { get; init; }

        [JsonPropertyName("phs")]
        public IList<string> PhotoUris { get; init; } = new List<string>(0);
    }

    public sealed record PetDto
    {
        public Guid Id { get; init; } = Guid.Empty;

        [JsonPropertyName("ch")]
        public string Chip { get; init; }

        [JsonPropertyName("nm")]
        public string Name { get; init; }

        [JsonPropertyName("br")]
        public string Breed { get; init; }

        [JsonPropertyName("clr")]
        public string Color { get; init; }

        [JsonPropertyName("knl")]
        public string Kennel { get; init; }

        [JsonPropertyName("bd")]
        public DateTimeOffset? BirthDate { get; init; } = null;
    }
}