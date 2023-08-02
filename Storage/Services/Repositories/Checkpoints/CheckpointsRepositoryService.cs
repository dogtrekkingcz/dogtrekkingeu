using MapsterMapper;
using MongoDB.Bson;
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
        BsonDocument filter = new BsonDocument();

        if (request.ActionId != null)
            filter.Add(nameof(CheckpointRecord.ActionId), request.ActionId.ToString());

        if (request.CheckpointId != null)
            filter.Add(nameof(CheckpointRecord.CheckpointId), request.CheckpointId.ToString());

        if (request.UserId != null)
            filter.Add(nameof(CheckpointRecord.UserId), request.UserId);
        
        // TODO: create logic for filtering by position and distance
        // TODO: create logic for filtering by time
         
        // if (request.Position != null && request.PositionDistanceInMeters != null)
        //     filter.Add(nameof(CheckpointRecord.Position.Latitude), )
        //
    //     filter.Add(nameof(CheckpointRecord.CheckpointTime), new BsonDocument("$gte", request.From));
    // }
    //     );
        
        var filteredRecords = await _checkpointService.GetByCustomFilterAsync(filter, cancellationToken);

        return new GetCheckpointItemsInternalStorageResponse
        {
            Items = filteredRecords
                .Select(r => _mapper.Map<GetCheckpointItemsInternalStorageResponse.CheckpointItemDto>(r))
                .ToList()
        };
    }
}