using MapsterMapper;
using MongoDB.Bson;
using Storage.Entities.Activities;
using Storage.Entities.Checkpoints;
using Storage.Extensions;
using Storage.Interfaces;
using Storage.Models;

namespace Storage.Services.Repositories.Activities;

internal class ActivitiesRepositoryService : IActivitiesRepositoryService
{
    private readonly IMapper _mapper;
    private readonly IStorageService<ActivityRecord> _activitiesService;

    public ActivitiesRepositoryService(IMapper mapper, IStorageService<ActivityRecord> activitiesService)
    {
        _mapper = mapper;
        _activitiesService = activitiesService;
    }

    public async Task<CreateActivityInternalStorageResponse> CreateActivityAsync(CreateActivityInternalStorageRequest request, CancellationToken cancellationToken)
    {
        Console.WriteLine($"ActivitiesRepository::{nameof(CreateActivityAsync)}: '{request?.Dump()}'");
            
        var addRequest = _mapper.Map<ActivityRecord>(request);
            
        var createdActivityRecord = await _activitiesService.AddAsync(addRequest, cancellationToken);

        var response = _mapper.Map<CreateActivityInternalStorageResponse>(createdActivityRecord);

        return response;
    }

    public async Task<AddPointInternalStorageResponse> AddPointAsync(AddPointInternalStorageRequest request, CancellationToken cancellationToken)
    {
        var activity = await _activitiesService.GetAsync(request.ActivityId.ToString(), cancellationToken);
        
        activity.Positions.Add(_mapper.Map<ActivityRecord.PositionDto>(request));

        await _activitiesService.UpdateAsync(activity, cancellationToken);

        return new AddPointInternalStorageResponse
        {
            Id = request.Id
        };
    }

    public async Task<GetActivitiesByUserIdInternalStorageResponse> GetActivitiesByUserId(string userId, CancellationToken cancellationToken)
    {
        var activities = await _activitiesService.GetByUserId(userId, cancellationToken);

        Console.WriteLine(activities.Dump());

        var response = new GetActivitiesByUserIdInternalStorageResponse
        {
            Activities = activities
                .Select(activity => _mapper.Map<GetActivitiesByUserIdInternalStorageResponse.ActivityDto>(activity))
                .ToList()
        };
        
        Console.WriteLine(response.Dump());

        return response;
    }
}