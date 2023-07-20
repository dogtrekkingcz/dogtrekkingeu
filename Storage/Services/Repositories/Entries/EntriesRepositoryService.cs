using SharedCode.Entities;
using MapsterMapper;
using Storage.Entities.Entries;
using Storage.Interfaces;
using Storage.Models;

namespace Storage.Services.Repositories.Entries;

internal sealed class EntriesRepositoryService : IEntriesRepositoryService
{
    private readonly IMapper _mapper;
    private readonly IStorageService<EntryRecord> _entriesStorageService;
    
    public EntriesRepositoryService(IMapper mapper, IStorageService<EntryRecord> entriesStorageService)
    {
        _mapper = mapper;
        _entriesStorageService = entriesStorageService;
    }
    
    public async Task<CreateEntryInternalStorageResponse> CreateEntryAsync(CreateEntryInternalStorageRequest request, CancellationToken cancellationToken)
    {
        var entryRecord = _mapper.Map<EntryRecord>(request);
        
        var createdEntry = await _entriesStorageService.AddAsync(entryRecord, cancellationToken);
        
        return new CreateEntryInternalStorageResponse { Id = createdEntry.Id };
    }

    public async Task<GetEntriesByActionInternalStorageResponse> GetEntriesByActionAsync(GetEntriesByActionInternalStorageRequest request, CancellationToken cancellationToken)
    {
        var entries = await _entriesStorageService.GetByFilterAsync(new List<(string, string)> { ("ActionId", request.ActionId)}, cancellationToken);

        var response = new GetEntriesByActionInternalStorageResponse
        {
            Entries = _mapper.Map<List<EntryDto>>(entries)
        };

        return response;
    }

    public async Task<GetAllEntriesInternalStorageResponse> GetAllEntriesAsync(GetAllEntriesInternalStorageRequest request, CancellationToken cancellationToken)
    {
        var entries = await _entriesStorageService.GetAllAsync(cancellationToken);

        var response = new GetAllEntriesInternalStorageResponse
        {
            Entries = _mapper.Map<List<EntryDto>>(entries)
        };

        return response;
    }

    public async Task DeleteEntryAsync(DeleteEntryInternalStorageRequest request, CancellationToken cancellationToken)
    {
        await _entriesStorageService.DeleteAsync(request.Id, cancellationToken);
    }

    public async Task<GetEntryResponse> GetAsync(Guid registrationId, CancellationToken cancellationToken)
    {
        var entry = await _entriesStorageService.GetAsync(registrationId.ToString(), cancellationToken);
        
        return _mapper.Map<GetEntryResponse>(entry);
    }
}