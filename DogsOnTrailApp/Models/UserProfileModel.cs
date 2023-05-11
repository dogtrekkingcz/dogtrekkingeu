using SharedCode.Entities;

namespace DogsOnTrailApp.Models;

public sealed record UserProfileModel : UserProfileDto
{
    public IList<ActionRightsDto> Rights { get; set; } = new List<ActionRightsDto>();
}