using SharedCode.Entities;

namespace DogsOnTrail.Interfaces.Actions.Entities.Results;

public sealed record AddResultRequest : RacerDto
{
    public string ActionId { get; set; } = string.Empty;

    public string RaceId { get; set; } = string.Empty;

    public string CategoryId { get; set; } = string.Empty;
}