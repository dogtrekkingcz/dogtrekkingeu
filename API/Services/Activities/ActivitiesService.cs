using MapsterMapper;
using PetsOnTrail.Actions.Attributes;
using PetsOnTrail.Interfaces.Actions.Entities.Activities;
using PetsOnTrail.Interfaces.Actions.Services;
using Storage.Entities.Activities;
using Storage.Interfaces;

namespace PetsOnTrail.Actions.Services.Activities;

internal class ActivitiesService : IActivitiesService
{
    private readonly IMapper _mapper;
    private readonly IActivitiesRepositoryService _activitiesRepositoryService;
    private readonly ICurrentUserIdService _currentUserIdService;
    
    public ActivitiesService(
        IMapper mapper, 
        ICurrentUserIdService currentUserIdService, 
        IActivitiesRepositoryService activitiesRepositoryService,
        ILiveUpdateSubscriptionService liveUpdateSubscriptionService)
    {
        _mapper = mapper;
        _activitiesRepositoryService = activitiesRepositoryService;
        _currentUserIdService = currentUserIdService;
    }
    
    public async Task<CreateActivityResponse> CreateActivityAsync(CreateActivityRequest request, CancellationToken cancellationToken)
    {
        var createInternalStorageRequest = _mapper.Map<CreateActivityInternalStorageRequest>(request) with
        {
            Id = request.Id is null ? Guid.NewGuid() : request.Id.Value,
            UserId = _currentUserIdService.GetUserId()
        };

        var response = await _activitiesRepositoryService.CreateActivityAsync(createInternalStorageRequest, cancellationToken);

        return _mapper.Map<CreateActivityResponse>(response);
    }

    public async Task<AddPointResponse> AddPointAsync(AddPointRequest request, CancellationToken cancellationToken)
    {
        var addPointInternalStorageRequest = _mapper.Map<AddPointInternalStorageRequest>(request) with
        {
            Id = Guid.NewGuid()
        };

        var response = await _activitiesRepositoryService.AddPointAsync(addPointInternalStorageRequest, cancellationToken);

        return _mapper.Map<AddPointResponse>(response);
    }

    public async Task<GetMyActivitiesResponse> GetMyActivitiesAsync(GetMyActivitiesRequest request, CancellationToken cancellationToken)
    {
        var activities = await _activitiesRepositoryService.GetActivitiesByUserId(_currentUserIdService.GetUserId(), cancellationToken);

        return _mapper.Map<GetMyActivitiesResponse>(activities);
    }

    [RequiredRoles(Constants.Roles.InternalAdministrator.Id, Constants.Roles.OwnerOfAction.Id)]
    public async Task<UpdateActivityResponse> UpdateActivityAsync(UpdateActivityRequest request, CancellationToken cancellationToken)
    {
        var updateInternalStorageRequest = _mapper.Map<UpdateActivityInternalStorageRequest>(request);

        var response = await _activitiesRepositoryService.UpdateActivityAsync(updateInternalStorageRequest, cancellationToken);

        return _mapper.Map<UpdateActivityResponse>(response);
    }
}