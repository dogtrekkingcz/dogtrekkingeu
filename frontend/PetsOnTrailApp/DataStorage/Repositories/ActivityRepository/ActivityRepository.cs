using MapsterMapper;
using PetsOnTrailApp.Models;
using Protos.Activities.GetActivityByUserIdAndActivityId;

namespace PetsOnTrailApp.DataStorage.Repositories.ActivityRepository;

public class ActivityRepository : BaseRepository, IActivityRepository
{
    private readonly IDataStorageService<Protos.Activities.GetActivityByUserIdAndActivityId.GetActivityByUserIdAndActivityIdResponse, GetActivityByUserIdAndActivityIdResponseModel> _dataStorageServiceActivityByUserIdAndActivityId;
    private readonly IDataStorageService<Protos.Activities.GetActivitiesByUserId.GetActivitiesByUserIdResponse, GetActivitiesByUserIdResponseModel> _dataStorageServiceActivityByUserId;
    private readonly IMapper _mapper;

    private static SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1, 1);

    public ActivityRepository(
        IDataStorageService<GetActivityByUserIdAndActivityIdResponse, GetActivityByUserIdAndActivityIdResponseModel> dataStorageServiceActivityByUserIdAndActivityId, 
        IMapper mapper,
        IDataStorageService<Protos.Activities.GetActivitiesByUserId.GetActivitiesByUserIdResponse, GetActivitiesByUserIdResponseModel> dataStorageServiceActivityByUserId)
    {
        _dataStorageServiceActivityByUserIdAndActivityId = dataStorageServiceActivityByUserIdAndActivityId;
        _mapper = mapper;
        _dataStorageServiceActivityByUserId = dataStorageServiceActivityByUserId;
    }

    public async Task<ActivityModel> GetActivityByUserIdAndActivityId(Protos.Activities.UserIdAndActivityId userIdAndActivityId, CancellationToken cancellationToken)
    {
        await semaphoreSlim.WaitAsync();
        try
        {
            var activities = await _dataStorageServiceActivityByUserIdAndActivityId.GetListAsync(new List<Guid> { Guid.Parse(userIdAndActivityId.UserId), Guid.Parse(userIdAndActivityId.ActivityId) }, cancellationToken);
            return _mapper.Map<ActivityModel>(activities.Data);
        }
        finally
        {
            semaphoreSlim.Release();
        }

        // await LoadAndParseActionsSimpleAsync(typeIds, cancellationToken);
    }

    public async Task<UserActivitiesModel> GetActivitiesByUserId(Protos.Activities.UserIdRequest userIdRequest, CancellationToken cancellationToken)
    {
        await semaphoreSlim.WaitAsync();
        try
        {
            var activities = await _dataStorageServiceActivityByUserId.GetAsync(Guid.Parse(userIdRequest.UserId), cancellationToken);
            return _mapper.Map<UserActivitiesModel>(activities.Data);
        }
        finally
        {
            semaphoreSlim.Release();
        }

        // await LoadAndParseActionsSimpleAsync(typeIds, cancellationToken);
    }
}
