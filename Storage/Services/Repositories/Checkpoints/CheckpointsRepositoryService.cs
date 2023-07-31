using MapsterMapper;
using Storage.Entities.Checkpoints;
using Storage.Entities.Dogs;
using Storage.Extensions;
using Storage.Interfaces;
using Storage.Models;

namespace Storage.Services.Repositories.Checkpoints;

internal class CheckpointsRepositoryService : ICheckpointsRepositoryService
{
    private readonly IMapper _mapper;
    private readonly IStorageService<CheckpointRecord> _checkpointService;

    public CheckpointsRepositoryService(IMapper mapper, IStorageService<CheckpointRecord> checkpointService)
    {
        _mapper = mapper;
        _checkpointService = checkpointService;
    }

    public async Task<AddCheckpointItemInternalStorageResponse> AddAsync(AddCheckpointItemInternalStorageRequest request, CancellationToken cancellationToken)
    {
        Console.WriteLine($"CheckpointsRepository::{nameof(AddAsync)}: '{request?.Dump()}'");
            
        var addRequest = _mapper.Map<CheckpointRecord>(request);
            
        var addedCheckpointRecord = await _checkpointService.AddAsync(addRequest, cancellationToken);

        var response = _mapper.Map<AddCheckpointItemInternalStorageResponse>(addedCheckpointRecord);

        return response;
    }

    public async Task<GetCheckpointItemsInternalStorageResponse> GetAsync(GetCheckpointItemsInternalStorageRequest request, CancellationToken cancellationToken)
    {
        var filter = new List<(string, IStorageService<CheckpointRecord>.FilterOptions options, DateTimeOffset value)>();
        filter.Add((nameof(CheckpointRecord.CheckpointTime), IStorageService<CheckpointRecord>.FilterOptions.MoreThanOrEqual, request.From));

        var filteredRecords = await _checkpointService.GetByTimeFilterAsync(filter, cancellationToken);

        return new GetCheckpointItemsInternalStorageResponse
        {
            Items = filteredRecords
                .Select(r => _mapper.Map<GetCheckpointItemsInternalStorageResponse.CheckpointItemDto>(r))
                .ToList()
        };
    }
}