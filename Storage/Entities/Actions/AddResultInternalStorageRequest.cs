using DogtrekkingCzShared.Entities;

namespace Storage.Entities.Actions;

public record AddResultInternalStorageRequest : RacerDto
{
    public Guid ActionId { get; set; } = Guid.Empty;

    public Guid RaceId { get; set; } = Guid.Empty;

    public Guid CategoryId { get; set; } = Guid.Empty;
}