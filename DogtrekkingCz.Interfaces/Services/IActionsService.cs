using DogtrekkingCz.Interfaces.Entities;

namespace DogtrekkingCz.Interfaces.Services
{
    public interface IActionsService
    {
        Task<ActionDetailResponse> GetActionDetail(ActionDetailRequest request, CancellationToken cancellationToken);
    }
}