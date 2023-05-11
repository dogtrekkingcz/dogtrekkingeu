using SharedCode.Entities;

namespace DogsOnTrailApp.Models;

public record ResultModel : RacerDto
{
    public Guid ActionId { get; set; } = Guid.Empty;

    public Guid RaceId { get; set; } = Guid.Empty;

    public Guid CategoryId { get; set; } = Guid.Empty;
}