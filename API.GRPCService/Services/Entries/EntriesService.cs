using DogsOnTrail.Interfaces.Actions.Services;
using Grpc.Core;
using MapsterMapper;
using Protos.Entries;
using CreateEntryRequest = DogsOnTrail.Interfaces.Actions.Entities.Entries.CreateEntryRequest;
using DeleteEntryRequest = DogsOnTrail.Interfaces.Actions.Entities.Entries.DeleteEntryRequest;
using GetAllEntriesRequest = DogsOnTrail.Interfaces.Actions.Entities.Entries.GetAllEntriesRequest;
using GetEntriesByActionRequest = DogsOnTrail.Interfaces.Actions.Entities.Entries.GetEntriesByActionRequest;

namespace API.GRPCService.Services.Entries;

internal class EntriesService : Protos.Entries.Entries.EntriesBase
{
    private readonly ILogger _logger;
    private readonly IMapper _mapper;
    private readonly IEntriesService _entriesService;

    public EntriesService(ILogger<EntriesService> logger, IMapper mapper, IEntriesService entriesService)
    {
        _logger = logger;
        _mapper = mapper;
        _entriesService = entriesService;
    }

    public async override Task<Protos.Entries.CreateEntry.CreateEntryResponse> createEntry(Protos.Entries.CreateEntry.CreateEntryRequest request, ServerCallContext context)
    {
        var createEntryRequest = _mapper.Map<CreateEntryRequest>(request);
        
        var newEntry = await _entriesService.CreateEntryAsync(createEntryRequest, context.CancellationToken);

        var response = _mapper.Map<Protos.Entries.CreateEntry.CreateEntryResponse>(newEntry);

        return response;
    }

    public async override Task<Protos.Entries.GetEntriesByAction.GetEntriesByActionResponse> getEntriesByAction(Protos.Entries.GetEntriesByActionRequest request, ServerCallContext context)
    {
        var getEntriesByActionRequest = _mapper.Map<GetEntriesByActionRequest>(request);

        var entries = await _entriesService.GetEntriesByActionAsync(getEntriesByActionRequest, context.CancellationToken);

        var response = _mapper.Map<Protos.Entries.GetEntriesByAction.GetEntriesByActionResponse>(entries);

        return response;
    }

    public async override Task<Protos.Entries.GetAllEntries.GetAllEntriesResponse> getAllEntries(Protos.Entries.GetAllEntriesRequest request, ServerCallContext context)
    {
        var getAllEntriesRequest = _mapper.Map<GetAllEntriesRequest>(request);

        var entries = await _entriesService.GetAllEntriesAsync(getAllEntriesRequest, context.CancellationToken);

        var response = _mapper.Map<Protos.Entries.GetAllEntries.GetAllEntriesResponse>(entries);

        return response;
    }

    public async override Task<Protos.Entries.DeleteEntryResponse> deleteEntry(Protos.Entries.DeleteEntryRequest request, ServerCallContext context)
    {
        var deleteEntryRequest = _mapper.Map<DeleteEntryRequest>(request);

        await _entriesService.DeleteEntryAsync(deleteEntryRequest, context.CancellationToken);

        return new DeleteEntryResponse();
    }
}