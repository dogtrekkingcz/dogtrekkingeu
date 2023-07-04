using DogsOnTrail.Interfaces.Actions.Entities;
using DogsOnTrail.Interfaces.Actions.Entities.Actions;

namespace DogsOnTrail.Interfaces.Actions.Services
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

        Task<GetActionEntrySettingsResponse> GetActionEntrySettings(GetActionEntrySettingsRequest request, CancellationToken cancellationToken);

        Task<GetSelectedActionsResponse> GetSelectedActionsAsync(GetSelectedActionsRequest request, CancellationToken cancellationToken);
    }
}