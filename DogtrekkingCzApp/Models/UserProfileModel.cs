using DogtrekkingCzShared.Entities;

namespace DogtrekkingCzApp.Models;

public sealed record UserProfileModel : UserProfileDto
{
    public IList<ActionRightsDto> Rights { get; set; } = new List<ActionRightsDto>();
}