using DogtrekkingCzShared.Entities;

namespace Storage.Entities.ActionRights
{
    public sealed record GetActionRightsResponse
    {
        public IReadOnlyList<ActionRightsDto> Rights { get; init; }
    }
}
