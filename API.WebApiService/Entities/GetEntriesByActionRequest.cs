using SharedCode.Entities;
using Mediator;

namespace DogsOnTrailWebApiService.Entities;

public sealed record GetEntriesByActionRequest : IRequest<GetEntriesByActionResponse>
{
    public string ActionId { get; set; }
}