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
            var user = await _profilesService.GetAsync(request.UserId, cancellationToken);
            if (user == null)
            {
                user = new UserProfileRecord
                {
                    Id = request.UserId,
                    UserId = request.UserId,
                    Roles = new List<Guid> { Constants.Roles.InternalUser.GUID },
                };
            }

            // into profile we store only the reference to activity, no position data; its in the activity table itself
            var activity = _mapper.Map<UserProfileRecord.ActivityDto>(request);
            activity.Positions = new List<UserProfileRecord.PositionDto>(0);    // no need to store positions in user profile
            user.Activities.Add(activity);

            var createdUserActivityRecord = await _profilesService.AddOrUpdateAsync(user, cancellationToken);

            response = new CreateActivityInternalStorageResponse
            {
                Id = Guid.Parse(activity.Id)
            };


            // and also store the users activity in activities collection
            addRequest.UserId = request.UserId;
            addRequest.CorrelationId = request.Id;
            if (addRequest.Positions == null)
                addRequest.Positions = new List<ActivityRecord.PositionDto>(0);

            // deal with continuation records... mongodb has a limit of 16MB per document
            if (addRequest.Positions.Count <= 500)
            { 
                var createdActivityRecord = await _activitiesService.AddOrUpdateAsync(addRequest, cancellationToken);
                response = _mapper.Map<CreateActivityInternalStorageResponse>(createdActivityRecord);
            }
            else
            {
                await _activitiesService.DeleteAllByCorrelationIdAsync(addRequest.Id, cancellationToken);

                for (int i = 0; i < addRequest.Positions.Count; i += 500)
                {
                    var positions = addRequest.Positions.Skip(i).Take(500).ToList();
                    addRequest.Positions = positions;
                    addRequest.Id = Guid.NewGuid();
                    addRequest.UserId = request.UserId;
                    addRequest.CorrelationId = request.Id;
                    var createdActivityRecord = await _activitiesService.AddOrUpdateAsync(addRequest, cancellationToken);
                    response = _mapper.Map<CreateActivityInternalStorageResponse>(createdActivityRecord);
                }
            }
            
        }

        return response;
    }

    public async Task<AddPointInternalStorageResponse> AddPointAsync(AddPointInternalStorageRequest request, CancellationToken cancellationToken)
    {
        var activity = await _activitiesService.GetAsync(request.ActivityId, cancellationToken);
        
        activity.Positions.Add(_mapper.Map<ActivityRecord.PositionDto>(request));

        await _activitiesService.AddOrUpdateAsync(activity, cancellationToken);

        return new AddPointInternalStorageResponse
        {
            Id = request.Id
        };
    }

    public async Task<GetActivitiesByUserIdInternalStorageResponse> GetActivitiesByUserId(Guid userId, CancellationToken cancellationToken)
    {
        var activities = await _activitiesService.GetByUserId(userId, cancellationToken);

        var response = _mapper.Map<GetActivitiesByUserIdInternalStorageResponse>(activities) with { UserId = userId };

        return response;
    }

    public async Task<GetActivityByUserIdAndActivityIdInternalStorageResponse> GetActivityByUserIdAndActivityId(Guid userId, Guid activityId, CancellationToken cancellationToken)
    {
        var activities = await _activitiesService.GetByUserIdAndCorrelationId(userId, activityId, cancellationToken);
        if (activities == null || activities.Count == 0)
        {
            _logger.LogWarning($"Storage: GetActivityByUserIdAndActivityId: No activity found for user '{userId}' and activity '{activityId}'");

            return new GetActivityByUserIdAndActivityIdInternalStorageResponse
            {
                UserId = userId
            };
        }

        _logger.LogInformation($"Storage: GetActivityByUserIdAndActivityId: {activities.Dump()}");

        var response = _mapper.Map<GetActivityByUserIdAndActivityIdInternalStorageResponse>(activities.FirstOrDefault()) with { UserId = userId };
        bool first = true;
        foreach (var activity in activities)
        {
            if (first)
            {
                first = false;
                continue;
            }

            response.Positions.AddRange(
                activity.Positions.Select(position => 
                    _mapper.Map<GetActivityByUserIdAndActivityIdInternalStorageResponse.PositionDto>(position)
                )
            );
        }

        return response;
    }

    public async Task<GetActivitiesInternalStorageResponse> GetActivitiesAsync(CancellationToken cancellationToken)
    {
        var activities = await _activitiesService.GetAllAsync(cancellationToken);

        return _mapper.Map<GetActivitiesInternalStorageResponse>(activities);
    }

    public async Task<UpdateActivityInternalStorageResponse> UpdateActivityAsync(UpdateActivityInternalStorageRequest request, CancellationToken cancellationToken)
    {
        var activity = await _activitiesService.GetAsync(request.Id, cancellationToken);

        activity.Positions.Add(_mapper.Map<ActivityRecord.PositionDto>(request));

        await _activitiesService.AddOrUpdateAsync(activity, cancellationToken);

        return new UpdateActivityInternalStorageResponse
        {
            Id = request.Id
        };
    }
}