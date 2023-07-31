using Storage.Entities.Checkpoints;

namespace Storage.Interfaces
{
    public interface ICheckpointsRepositoryService : IRepositoryService
    {
        Task<AddCheckpointItemInternalStorageResponse> AddAsync(AddCheckpointItemInternalStorageRequest request, CancellationToken cancellationToken);

        Task<GetCheckpointItemsInternalStorageResponse> GetAsync(GetCheckpointItemsInternalStorageRequest request, CancellationToken cancellationToken);
    }
}
