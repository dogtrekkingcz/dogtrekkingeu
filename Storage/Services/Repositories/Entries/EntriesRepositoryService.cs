using MapsterMapper;
using Storage.Entities.Entries;
using Storage.Extensions;
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
        Console.WriteLine($"{nameof(GetEntriesByActionAsync)} - request: '{request?.Dump()}'");
        
        var entries = await _entriesStorageService.GetByFilterAsync(
            new List<(string, Type, object)>
            {
                ("ActionId", typeof(Guid), request.ActionId),
                ("Accepted", typeof(bool), request.IncludeAlreadyAccepted)
            },
            cancellationToken);
        
        Console.WriteLine($"{nameof(GetEntriesByActionAsync)} - response from storage: '{entries?.Dump()}'");

        var response = new GetEntriesByActionInternalStorageResponse
        {
            Entries = _mapper.Map<List<GetEntriesByActionInternalStorageResponse.EntryDto>>(entries)
        };

        return response;
    }

    public async Task<GetAllEntriesInternalStorageResponse> GetAllEntriesAsync(GetAllEntriesInternalStorageRequest request, CancellationToken cancellationToken)
    {
        var entries = await _entriesStorageService.GetAllAsync(cancellationToken);

        var response = new GetAllEntriesInternalStorageResponse
        {
            Entries = _mapper.Map<List<GetAllEntriesInternalStorageResponse.EntryDto>>(entries)
        };

        return response;
    }

    public async Task DeleteEntryAsync(DeleteEntryInternalStorageRequest request, CancellationToken cancellationToken)
    {
        await _entriesStorageService.DeleteAsync(request.Id, cancellationToken);
    }

    public async Task<GetEntryInternalStorageResponse> GetAsync(Guid registrationId, CancellationToken cancellationToken)
    {
        var entry = await _entriesStorageService.GetAsync(registrationId.ToString(), cancellationToken);
        
        return _mapper.Map<GetEntryInternalStorageResponse>(entry);
    }

    public async Task UpdateEntryAsync(UpdateEntryInternalStorageRequest request, CancellationToken cancellationToken)
    {
        await _entriesStorageService.UpdateAsync(_mapper.Map<EntryRecord>(request), cancellationToken);
    }
}