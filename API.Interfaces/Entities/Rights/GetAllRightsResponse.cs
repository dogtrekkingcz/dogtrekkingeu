using SharedCode.Entities;

namespace DogsOnTrail.Interfaces.Actions.Entities.Rights
{
    public sealed record GetAllRightsResponse
    {
        public IReadOnlyList<ActionRightsDto> Rights { get; init; }
    }
}
