using MapsterMapper;
using Microsoft.Extensions.Logging;
using Storage.Entities.Activities;
using Storage.Extensions;
using Storage.Interfaces;
using Storage.Models;

namespace Storage.Services.Repositories.Activities;

internal class ActivitiesRepositoryService : IActivitiesRepositoryService
{
    private readonly ILogger<ActivitiesRepositoryService> _logger;
    private readonly IMapper _mapper;
    private readonly IStorageService<ActivityRecord> _activitiesService;
    private readonly IStorageService<UserProfileRecord> _profilesService;

    public ActivitiesRepositoryService(IMapper mapper, IStorageService<ActivityRecord> activitiesService, IStorageService<UserProfileRecord> profilesService, ILogger<ActivitiesRepositoryService> logger)
    {
        _mapper = mapper;
        _activitiesService = activitiesService;
        _profilesService = profilesService;
        _logger = logger;
    }

    public async Task<CreateActivityInternalStorageResponse> CreateActivityAsync(CreateActivityInternalStorageRequest request, CancellationToken cancellationToken)
    {
        Console.WriteLine($"ActivitiesRepository::{nameof(CreateActivityAsync)}: '{request?.Dump()}'");

        CreateActivityInternalStorageResponse response = null;
            
        var addRequest = _mapper.Map<ActivityRecord>(request);
        
        if (request.UserId == Guid.Empty)
        {
            var createdActivityRecord = await _activitiesService.AddOrUpdateAsync(addRequest, cancellationToken);
            response = _mapper.Map<CreateActivityInternalStorageResponse>(createdActivityRecord);
        }
        else
        {
            var user = await _profilesService.GetAsync(request.UserId.ToString(), cancellationToken);
            if (user == null)
            {
                user = new UserProfileRecord
                {
                    Id = request.UserId.ToString(),
                    UserId = request.UserId.ToString(),
                    Roles = new List<Guid> { Guid.Parse(Constants.Roles.InternalUser.Id) },
                };
            }

            var activity = _mapper.Map<UserProfileRecord.ActivityDto>(request);
            user.Activities.Add(activity);

            var createdActivityRecord = await _profilesService.AddOrUpdateAsync(user, cancellationToken);

            response = new CreateActivityInternalStorageResponse
            {
                Id = Guid.Parse(activity.Id)
            };
        }

        return response;
    }

    public async Task<AddPointInternalStorageResponse> AddPointAsync(AddPointInternalStorageRequest request, CancellationToken cancellationToken)
    {
        var activity = await _activitiesService.GetAsync(request.ActivityId.ToString(), cancellationToken);
        
        activity.Positions.Add(_mapper.Map<ActivityRecord.PositionDto>(request));

        await _activitiesService.AddOrUpdateAsync(activity, cancellationToken);

        return new AddPointInternalStorageResponse
        {
            Id = request.Id
        };
    }

    public async Task<GetActivitiesByUserIdInternalStorageResponse> GetActivitiesByUserId(Guid userId, CancellationToken cancellationToken)
    {
        var activities = await _activitiesService.GetByUserId(userId.ToString(), cancellationToken);

        return _mapper.Map<GetActivitiesByUserIdInternalStorageResponse>(activities);
    }

    public async Task<GetActivityByUserIdAndActivityIdInternalStorageResponse> GetActivityByUserIdAndActivityId(Guid userId, string activityId, CancellationToken cancellationToken)
    {
        var profile = await _profilesService.GetAsync(userId.ToString(), cancellationToken);

        var activity = profile.Activities.FirstOrDefault(a => a.Id == activityId);
        _logger.LogInformation($"Storage: GetActivityByUserIdAndActivityId: {activity.Dump()}");

        return _mapper.Map<GetActivityByUserIdAndActivityIdInternalStorageResponse>(activity);
    }

    public async Task<GetActivitiesInternalStorageResponse> GetActivitiesAsync(CancellationToken cancellationToken)
    {
        var activities = await _activitiesService.GetAllAsync(cancellationToken);

        return _mapper.Map<GetActivitiesInternalStorageResponse>(activities);
    }

    public async Task<UpdateActivityInternalStorageResponse> UpdateActivityAsync(UpdateActivityInternalStorageRequest request, CancellationToken cancellationToken)
    {
        var activity = await _activitiesService.GetAsync(request.Id.ToString(), cancellationToken);

        activity.Positions.Add(_mapper.Map<ActivityRecord.PositionDto>(request));

        await _activitiesService.AddOrUpdateAsync(activity, cancellationToken);

        return new UpdateActivityInternalStorageResponse
        {
            Id = request.Id
        };
    }
}