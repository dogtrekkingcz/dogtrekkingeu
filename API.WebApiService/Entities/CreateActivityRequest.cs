using Mediator;

namespace API.WebApiService.Entities;

public sealed record CreateActivityRequest : IRequest<CreateActivityResponse>
{
    public Guid IdActivity { get; init; } = Guid.NewGuid();

    public DateTimeOffset Created { get; init; } = DateTimeOffset.Now;

    public string Name { get; init; } = string.Empty;

    public string Description { get; init; } = string.Empty;

    public string Type { get; init; } = string.Empty;


    public List<ActivityPetDto> Pets { get; init; } = new List<ActivityPetDto>();

    public List<ActivityPointDto> Points { get; init; } = new List<ActivityPointDto>();

    public sealed record ActivityPetDto
    {
        public Guid Id { get; init; } = Guid.NewGuid();

        public string? Chip { get; init; }

        public string? Name { get; init; }

        public string? Breed { get; init; }

        public string? Color { get; init; }

        public string Kennel { get; init; }

        public DateTimeOffset? BirthDate { get; init; }
    }

    public sealed record ActivityPointDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public DateTimeOffset Time { get; set; } = DateTimeOffset.Now;

        public double Latitude { get; set; } = double.NaN;

        public double Longitude { get; set; } = double.NaN;

        public double Altitude { get; set; } = double.NaN;

        public double Accuracy { get; set; } = double.NaN;

        public double Course { get; set; } = double.NaN;

        public string Note { get; set; } = string.Empty;

        public List<string> PhotoUris { get; set; } = new();
    }
}
