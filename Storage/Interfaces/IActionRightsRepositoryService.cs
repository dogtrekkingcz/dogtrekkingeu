using Storage.Entities.ActionRights;
using Storage.Entities.Dogs;

namespace Storage.Interfaces
{
    public interface IActionRightsRepositoryService : IRepositoryService
    {
        Task<AddActionRightsInternalStorageResponse> AddActionRightsAsync(AddActionRightsInternalStorageRequest request, CancellationToken cancellationToken);

        Task<GetAllRightsInternalStorageResponse> GetAllRightsAsync(GetAllRightsInternalStorageRequest request, CancellationToken cancellationToken);

        Task DeleteActionRightsAsync(DeleteActionRightsRequest request, CancellationToken cancellationToken);
    }
}
