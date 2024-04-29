﻿using MapsterMapper;
using PetsOnTrailApp.Models;
using Protos.Activities.GetActivityByUserIdAndActivityId;

namespace PetsOnTrailApp.DataStorage.Repositories.ActivityRepository;

public class ActivityRepository : IActivityRepository
{
    private readonly IDataStorageService<Protos.Activities.GetActivityByUserIdAndActivityId.GetActivityByUserIdAndActivityIdResponse, GetActivityByUserIdAndActivityIdResponseModel> _dataStorageServiceActivityByUserIdAndActivityId;
    private readonly IMapper _mapper;

    private static SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1, 1);

    public ActivityRepository(IDataStorageService<GetActivityByUserIdAndActivityIdResponse, GetActivityByUserIdAndActivityIdResponseModel> dataStorageServiceActivityByUserIdAndActivityId, IMapper mapper)
    {
        _dataStorageServiceActivityByUserIdAndActivityId = dataStorageServiceActivityByUserIdAndActivityId;
        _mapper = mapper;
    }

    public async Task<ActivityModel> GetActivityByUserIdAndActivityId(Protos.Activities.UserIdAndActivityId userIdAndActivityId, CancellationToken cancellationToken)
    {
        await semaphoreSlim.WaitAsync();
        try
        {
            var data = _dataStorageServiceActivityByUserIdAndActivityId.GetValueOrDefault(userIdAndActivityId, default(ActivityModel));
        }
        finally
        {
            semaphoreSlim.Release();
        }

        // await LoadAndParseActionsSimpleAsync(typeIds, cancellationToken);
    }
}
