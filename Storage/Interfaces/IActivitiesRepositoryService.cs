using Storage.Entities.Activities;
using Storage.Entities.Checkpoints;

namespace Storage.Interfaces
{
    public interface IActivitiesRepositoryService : IRepositoryService
    {
        Task<CreateActivityInternalStorageResponse> CreateActivityAsync(CreateActivityInternalStorageRequest internalStorageRequest, CancellationToken cancellationToken);

        Task<AddPointInternalStorageResponse> AddPointAsync(AddPointInternalStorageRequest request, CancellationToken cancellationToken);

        Task<GetActivitiesByUserIdInternalStorageResponse> GetActivitiesByUserId(Guid userId, CancellationToken cancellationToken);

        Task<GetActivityByUserIdAndActivityIdInternalStorageResponse> GetActivityByUserIdAndActivityId(Guid userId, Guid activityId, CancellationToken cancellationToken);

        Task<GetActivitiesInternalStorageResponse> GetActivitiesAsync(CancellationToken cancellationToken);

        Task<UpdateActivityInternalStorageResponse> UpdateActivityAsync(UpdateActivityInternalStorageRequest request, CancellationToken cancellationToken);
    }
}
