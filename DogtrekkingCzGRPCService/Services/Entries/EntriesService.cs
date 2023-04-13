using DogtrekkingCz.Entries.Interface.Entities;
using DogtrekkingCz.Entries.Interface.Services;
using Grpc.Core;
using MapsterMapper;

namespace DogtrekkingCzGRPCService.Services.Entries;

internal class EntriesService : Protos.Entries.Entries.EntriesBase
{
    private readonly ILogger _logger;
    private readonly IMapper _mapper;
    private readonly IEntriesService _entriesService;

    public EntriesService(ILogger logger, IMapper mapper, IEntriesService entriesService)
    {
        _logger = logger;
        _mapper = mapper;
        _entriesService = entriesService;
    }

    public async override Task<Protos.Entries.CreateEntryResponse> createEntry(Protos.Entries.CreateEntryRequest request, ServerCallContext context)
    {
        var createEntryRequest = _mapper.Map<CreateEntryRequest>(request);
        
        var newEntry = await _entriesService.CreateEntryAsync(createEntryRequest, context.CancellationToken);

        var response = _mapper.Map<Protos.Entries.CreateEntryResponse>(newEntry);

        return response;
    }
}