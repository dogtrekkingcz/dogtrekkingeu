using Storage.Entities.ActionRights;
using Storage.Entities.Dogs;

namespace Storage.Interfaces
{
    public interface IActionRightsRepositoryService : IRepositoryService
    {
        Task<AddActionRightsResponse> AddActionRightsAsync(AddActionRightsRequest request);

        Task<GetActionRightsResponse> GetActionRightsAsync(GetActionRightsRequest request);

        Task DeleteActionRightsAsync(DeleteActionRightsRequest request);
    }
}
