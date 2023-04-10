using DogtrekkingCz.Interfaces.Actions.Entities;

namespace DogtrekkingCz.Interfaces.Actions.Services
{
    public interface IActionsService
    {
        Task<ActionDetailResponse> GetActionDetail(ActionDetailRequest request, CancellationToken cancellationToken);
    }
}