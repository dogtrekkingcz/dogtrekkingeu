using Amazon.Runtime.Internal;
using MapsterMapper;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
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
            // in case of identified user we need to store activity in user profile
            // TODO: think about it, should be sufficient to store it only in activities and in user profile lets enter only path to activities... ?
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

            // into profile we store only the reference to activity, no position data; its in the activity table itself
            var activity = _mapper.Map<UserProfileRecord.ActivityDto>(request);
            user.Activities.Add(activity);

            var createdUserActivityRecord = await _profilesService.AddOrUpdateAsync(user, cancellationToken);

            response = new CreateActivityInternalStorageResponse
            {
                Id = Guid.Parse(activity.Id)
            };


            // and also store the users activity in activities collection
            addRequest.UserId = request.UserId.ToString();
            var createdActivityRecord = await _activitiesService.AddOrUpdateAsync(addRequest, cancellationToken);
            response = _mapper.Map<CreateActivityInternalStorageResponse>(createdActivityRecord);
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

        var response = _mapper.Map<GetActivitiesByUserIdInternalStorageResponse>(activities) with { UserId = userId };

        return response;
    }

    public async Task<GetActivityByUserIdAndActivityIdInternalStorageResponse> GetActivityByUserIdAndActivityId(Guid userId, string activityId, CancellationToken cancellationToken)
    {
        BsonDocument filter = new BsonDocument();
        filter
            .Add(nameof(ActivityRecord.UserId), userId.ToString())
            .Add(nameof(ActivityRecord.Id), activityId);

        var activities = await _activitiesService.GetByCustomFilterAsync(filter, cancellationToken);

        _logger.LogInformation($"Storage: GetActivityByUserIdAndActivityId: {activities.Dump()}");

        return _mapper.Map<GetActivityByUserIdAndActivityIdInternalStorageResponse>(activities.FirstOrDefault()) with { UserId = userId };
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