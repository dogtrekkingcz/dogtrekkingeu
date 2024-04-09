using PetsOnTrail.Actions.Extensions;
using PetsOnTrail.Interfaces.Actions.Entities.Checkpoints;
using PetsOnTrail.Interfaces.Actions.Entities.LiveUpdateSubscription;
using PetsOnTrail.Interfaces.Actions.Services;
using MapsterMapper;
using Storage.Entities.Checkpoints;
using Storage.Interfaces;

namespace PetsOnTrail.Actions.Services.Checkpoints;

public class CheckpointsService : ICheckpointsService
{
    private readonly IMapper _mapper;
    private readonly ICheckpointsRepositoryService _checkpointsRepositoryService;
    private readonly ICurrentUserIdService _currentUserIdService;
    private readonly ILiveUpdateSubscriptionService _liveUpdateSubscriptionService;
    
    public CheckpointsService(
        IMapper mapper, 
        ICurrentUserIdService currentUserIdService, 
        ICheckpointsRepositoryService checkpointsRepositoryService,
        ILiveUpdateSubscriptionService liveUpdateSubscriptionService)
    {
        _mapper = mapper;
        _checkpointsRepositoryService = checkpointsRepositoryService;
        _currentUserIdService = currentUserIdService;
        _liveUpdateSubscriptionService = liveUpdateSubscriptionService;
    }
    
    public async Task<AddCheckpointItemResponse> AddAsync(AddCheckpointItemRequest request, CancellationToken cancellationToken)
    {
        var addInternalStorageRequest = _mapper.Map<AddCheckpointItemInternalStorageRequest>(request) with
        {
            Id = Guid.NewGuid(),
            UserId = _currentUserIdService.GetUserId(),
            ServerTime = DateTimeOffset.Now,
            Created = DateTimeOffset.Now
        };

        var response = await _checkpointsRepositoryService.AddAsync(addInternalStorageRequest, cancellationToken);

        await _liveUpdateSubscriptionService.SendAsync(new SendLiveUpdateRequest
        {
            FromSection = Constants.LiveUpdateSections.Checkpoints,
            ToSection = Constants.LiveUpdateSections.Checkpoints,
            FromUser = _currentUserIdService.GetUserId(),
            Data = request.Dump(),
            Message = $"[Checkpoint] [{request.Name}] - {request.Data}"
        }, cancellationToken);
        
        return _mapper.Map<AddCheckpointItemResponse>(response);
    }

    public async Task<GetCheckpointItemsResponse> GetAsync(GetCheckpointItemsRequest request, CancellationToken cancellationToken)
    {
        var getInternalStorageRequest = _mapper.Map<GetCheckpointItemsInternalStorageRequest>(request);

        var response = await _checkpointsRepositoryService.GetAsync(getInternalStorageRequest, cancellationToken);

        return _mapper.Map<GetCheckpointItemsResponse>(response);
    }
}