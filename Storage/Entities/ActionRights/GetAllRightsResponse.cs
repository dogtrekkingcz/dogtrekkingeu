using DogtrekkingCzShared.Entities;

namespace Storage.Entities.ActionRights
{
    public sealed record GetAllRightsResponse
    {
        public IReadOnlyList<ActionRightsDto> Rights { get; init; }
    }
}
