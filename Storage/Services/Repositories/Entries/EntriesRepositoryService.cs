using DogtrekkingCz.Storage.Entities.Entries;
using MapsterMapper;
using Storage.Interfaces;

namespace Storage.Services.Repositories.Entries;

internal sealed class EntriesRepositoryService : IEntriesRepositoryService
{
    private readonly IMapper _mapper;
    private readonly IEntriesRepositoryService _entriesRepositoryService;
    
    public EntriesRepositoryService(IMapper mapper, IEntriesRepositoryService entriesRepositoryService)
    {
        _mapper = mapper;
        _entriesRepositoryService = entriesRepositoryService;
    }
    
    public async Task<CreateEntryStorageResponse> CreateEntryAsync(CreateEntryStorageRequest request, CancellationToken cancellationToken)
    {
        var createEntryRequest = _mapper.Map<CreateEntryStorageRequest>(request);
        
        var createdEntry = await _entriesRepositoryService.CreateEntryAsync(createEntryRequest, cancellationToken);
        
        return await Task.FromResult(new CreateEntryStorageResponse { Id = Guid.NewGuid() });
    }
}