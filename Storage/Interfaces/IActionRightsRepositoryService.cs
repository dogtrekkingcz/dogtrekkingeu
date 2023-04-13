using Storage.Entities.ActionRights;
using Storage.Entities.Dogs;

namespace Storage.Interfaces
{
    public interface IActionRightsRepositoryService : IRepositoryService
    {
        Task<AddActionRightsResponse> AddActionRightsAsync(AddActionRightsRequest request, CancellationToken cancellationToken);

        Task<GetAllRightsResponse> GetAllRightsAsync(GetAllRightsRequest request, CancellationToken cancellationToken);

        Task DeleteActionRightsAsync(DeleteActionRightsRequest request, CancellationToken cancellationToken);
    }
}
