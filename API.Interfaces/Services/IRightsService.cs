using PetsOnTrail.Interfaces.Actions.Entities.Rights;

namespace PetsOnTrail.Interfaces.Actions.Services
{
    public interface IRightsService
    {
        Task<GetAllRightsResponse> GetAllRightsAsync(GetAllRightsRequest request, CancellationToken cancellationToken);
    }
}