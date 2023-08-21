using Storage.Entities.Activities;
using Storage.Entities.Checkpoints;

namespace Storage.Interfaces
{
    public interface IActivitiesRepositoryService : IRepositoryService
    {
        Task<CreateActivityInternalStorageResponse> CreateActivityAsync(CreateActivityInternalStorageRequest internalStorageRequest, CancellationToken cancellationToken);

        Task<AddPointInternalStorageResponse> AddPointAsync(AddPointInternalStorageRequest request, CancellationToken cancellationToken);
    }
}
