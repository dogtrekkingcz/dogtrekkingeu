using SharedCode.Entities;
using Mediator;

namespace DogsOnTrailWebApiService.Entities;

public sealed record CreateEntryRequest : EntryDto, IRequest<CreateEntryResponse>
{
    
}