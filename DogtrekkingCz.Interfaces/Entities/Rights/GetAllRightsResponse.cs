using DogtrekkingCzShared.Entities;

namespace DogtrekkingCz.Interfaces.Actions.Entities.Rights
{
    public sealed record GetAllRightsResponse
    {
        public IReadOnlyList<ActionRightsDto> Rights { get; init; }
    }
}
