using DogsOnTrail.Interfaces.Actions.Entities.Rights;

namespace DogsOnTrail.Interfaces.Actions.Services
{
    public interface IRightsService
    {
        Task<GetAllRightsResponse> GetAllRightsAsync(GetAllRightsRequest request, CancellationToken cancellationToken);
    }
}