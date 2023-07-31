using DogsOnTrail.Interfaces.Actions.Entities.Checkpoints;
using DogsOnTrail.Interfaces.Actions.Services;
using MapsterMapper;
using Storage.Entities.Checkpoints;
using Storage.Interfaces;

namespace DogsOnTrail.Actions.Services.Checkpoints;

public class CheckpointsService : ICheckpointsService
{
    private readonly IMapper _mapper;
    private readonly ICheckpointsRepositoryService _checkpointsRepositoryService;
    
    public CheckpointsService(IMapper mapper, ICheckpointsRepositoryService checkpointsRepositoryService)
    {
        _mapper = mapper;
        _checkpointsRepositoryService = checkpointsRepositoryService;
    }
    
    public async Task<AddCheckpointItemResponse> AddAsync(AddCheckpointItemRequest request, CancellationToken cancellationToken)
    {
        var addInternalStorageRequest = _mapper.Map<AddCheckpointItemInternalStorageRequest>(request) with
        {
            Id = Guid.NewGuid(),
            ServerTime = DateTimeOffset.Now,
            Created = DateTimeOffset.Now
        };

        var response = await _checkpointsRepositoryService.AddAsync(addInternalStorageRequest, cancellationToken);

        return _mapper.Map<AddCheckpointItemResponse>(response);
    }

    public async Task<GetCheckpointItemsResponse> GetAsync(GetCheckpointItemsRequest request, CancellationToken cancellationToken)
    {
        var getInternalStorageRequest = _mapper.Map<GetCheckpointItemsInternalStorageRequest>(request);

        var response = await _checkpointsRepositoryService.GetAsync(getInternalStorageRequest, cancellationToken);

        return _mapper.Map<GetCheckpointItemsResponse>(response);
    }
}