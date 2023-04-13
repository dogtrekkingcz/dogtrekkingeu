using DogtrekkingCzShared.Entities;
using Mediator;

namespace DogtrekkingCzWebApiService.Entities;

public sealed record GetEntriesByActionRequest : IRequest<GetEntriesByActionResponse>
{
    public string ActionId { get; set; }
}