using DogtrekkingCz.Interfaces.Actions.Entities.Rights;

namespace DogtrekkingCz.Interfaces.Actions.Services
{
    public interface IRightsService
    {
        Task<GetAllRightsResponse> GetAllRightsAsync(GetAllRightsRequest request, CancellationToken cancellationToken);
    }
}