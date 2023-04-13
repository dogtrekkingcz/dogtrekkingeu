using DogtrekkingCzShared.Entities;
using Mediator;

namespace DogtrekkingCzWebApiService.Entities;

public sealed record CreateEntryRequest : EntryDto, IRequest<CreateEntryResponse>
{
    
}