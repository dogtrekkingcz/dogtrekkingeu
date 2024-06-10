using MapsterMapper;
using PetsOnTrail.Actions.Attributes;
using PetsOnTrail.Interfaces.Actions.Entities.Activities;
using PetsOnTrail.Interfaces.Actions.Services;
using Storage.Entities.Activities;
using Storage.Interfaces;
using System.Collections.Generic;

namespace PetsOnTrail.Actions.Services.Activities;

internal class ActivitiesService : IActivitiesService
{
    private readonly IMapper _mapper;
    private readonly IActivitiesRepositoryService _activitiesRepositoryService;
    private readonly IActivityTypeRepositoryService _activityTypeRepositoryService;
    private readonly ICurrentUserIdService _currentUserIdService;
    
    public ActivitiesService(
        IMapper mapper, 
        ICurrentUserIdService currentUserIdService, 
        IActivitiesRepositoryService activitiesRepositoryService,
        IActivityTypeRepositoryService activityTypeRepositoryService,
        ILiveUpdateSubscriptionService liveUpdateSubscriptionService)
    {
        _mapper = mapper;
        _activitiesRepositoryService = activitiesRepositoryService;
        _activityTypeRepositoryService = activityTypeRepositoryService;
        _currentUserIdService = currentUserIdService;
    }
    
    public async Task<CreateActivityResponse> CreateActivityAsync(CreateActivityRequest request, CancellationToken cancellationToken)
    {
        var createInternalStorageRequest = _mapper.Map<CreateActivityInternalStorageRequest>(request) with
        {
            Id = request.Id is null ? Guid.NewGuid() : request.Id.Value,
            UserId = request.UserId
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

    public async Task<AddPointsResponse> AddPointsAsync(AddPointsRequest request, CancellationToken cancellationToken)
    {
        var activity = await _activitiesRepositoryService.GetActivityByUserIdAndActivityId(_currentUserIdService.GetUserId(), request.ActivityId.ToString(), cancellationToken);

        List<CreateActivityInternalStorageRequest.PositionDto> positions = activity.Positions.Select(p => _mapper.Map<CreateActivityInternalStorageRequest.PositionDto>(p)).ToList();
        positions.AddRange(request.Points.Select(p => _mapper.Map<CreateActivityInternalStorageRequest.PositionDto>(p)));

        var updateActivityRequest = _mapper.Map<CreateActivityInternalStorageRequest>(activity) with
        {
            Positions = positions.DistinctBy(p => p.Id).ToList()
        };
        var response = await _activitiesRepositoryService.CreateActivityAsync(updateActivityRequest, cancellationToken);
        
        return _mapper.Map<AddPointsResponse>(response);
    }

    public async Task<GetMyActivitiesResponse> GetMyActivitiesAsync(GetMyActivitiesRequest request, CancellationToken cancellationToken)
    {
        var activities = await _activitiesRepositoryService.GetActivitiesByUserId(_currentUserIdService.GetUserId(), cancellationToken);

        return _mapper.Map<GetMyActivitiesResponse>(activities);
    }

    public async Task<GetActivitiesResponse> GetActivitiesAsync(CancellationToken cancellationToken)
    {
        var activities = await _activitiesRepositoryService.GetActivitiesAsync(cancellationToken);

        return _mapper.Map<GetActivitiesResponse>(activities);
    }

    public async Task<GetActivityByUserIdAndActivityIdResponse> GetActivityByUserIdAndActivityIdAsync(Guid userId, Guid activityId, CancellationToken cancellationToken)
    {
        var response = await _activitiesRepositoryService.GetActivityByUserIdAndActivityId(userId, activityId.ToString(), cancellationToken);

        return _mapper.Map<GetActivityByUserIdAndActivityIdResponse>(response);
    }

    [RequiredRoles(Constants.Roles.InternalAdministrator.Id, Constants.Roles.OwnerOfAction.Id)]
    public async Task<UpdateActivityResponse> UpdateActivityAsync(UpdateActivityRequest request, CancellationToken cancellationToken)
    {
        var updateInternalStorageRequest = _mapper.Map<UpdateActivityInternalStorageRequest>(request);

        var response = await _activitiesRepositoryService.UpdateActivityAsync(updateInternalStorageRequest, cancellationToken);

        return _mapper.Map<UpdateActivityResponse>(response);
    }

    public async Task<GetActivityTypesResponse> GetActivityTypesAsync(CancellationToken cancellationToken)
    {
        var activityTypes = await _activityTypeRepositoryService.GetAllAsync(cancellationToken);

        return _mapper.Map<GetActivityTypesResponse>(activityTypes);
    }

    public async Task<GetActivitiesByUserIdResponse> GetActivitiesByUserIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        var activities = await _activitiesRepositoryService.GetActivitiesByUserId(userId, cancellationToken);

        return _mapper.Map<GetActivitiesByUserIdResponse>(activities);
    }
}