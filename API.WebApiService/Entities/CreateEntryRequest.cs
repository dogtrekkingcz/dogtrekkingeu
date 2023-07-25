using Mediator;
using SharedCode.Entities;

namespace API.WebApiService.Entities;

public sealed record CreateEntryRequest : EntryDto, IRequest<CreateEntryResponse>
{
    
}