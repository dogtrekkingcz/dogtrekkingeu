using DogtrekkingCz.Interfaces.Actions.Entities;
using DogtrekkingCz.Interfaces.Actions.Entities.Actions;

namespace DogtrekkingCz.Interfaces.Actions.Services
{
    public interface IActionsService
    {
        Task<CreateActionResponse> CreateActionAsync(CreateActionRequest request, CancellationToken cancellationToken);

        Task<UpdateActionResponse> UpdateActionAsync(UpdateActionRequest request, CancellationToken cancellationToken);
        
        Task<GetActionDetailResponse> GetActionDetailAsync(GetActionDetailRequest request, CancellationToken cancellationToken);

        Task<GetAllActionsResponse> GetAllActionsAsync(GetAllActionsRequest request, CancellationToken cancellationToken);

        Task<GetAllActionsWithDetailsResponse> GetAllActionsWithDetailsAsync(GetAllActionsWithDetailsRequest request, CancellationToken cancellationToken);

        Task<GetActionResponse> GetActionAsync(GetActionRequest request, CancellationToken cancellationToken);

        Task DeleteActionAsync(DeleteActionRequest request, CancellationToken cancellationToken);
    }
}