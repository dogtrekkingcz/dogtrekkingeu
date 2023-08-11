using DogsOnTrail.Interfaces.Actions.Entities;
using DogsOnTrail.Interfaces.Actions.Entities.Actions;
using DogsOnTrail.Interfaces.Actions.Entities.Results;

namespace DogsOnTrail.Interfaces.Actions.Services
{
    public interface IActionsService
    {
        Task<CreateActionResponse> CreateActionAsync(CreateActionRequest request, CancellationToken cancellationToken);

        Task<UpdateActionResponse> UpdateActionAsync(UpdateActionRequest request, CancellationToken cancellationToken);
        
        Task<GetActionDetailResponse> GetActionDetailAsync(Guid id, CancellationToken cancellationToken);

        Task<GetAllActionsResponse> GetAllActionsAsync(GetAllActionsRequest request, CancellationToken cancellationToken);

        Task<GetAllActionsWithDetailsResponse> GetAllActionsWithDetailsAsync(GetAllActionsWithDetailsRequest request, CancellationToken cancellationToken);

        Task<GetActionResponse> GetActionAsync(Guid id, CancellationToken cancellationToken);

        Task DeleteActionAsync(Guid id, CancellationToken cancellationToken);

        Task<GetActionEntrySettingsResponse> GetActionEntrySettings(Guid id, CancellationToken cancellationToken);

        Task<GetSelectedActionsResponse> GetSelectedActionsAsync(GetSelectedActionsRequest request, CancellationToken cancellationToken);

        Task AcceptRegistrationAsync(Guid registrationId, CancellationToken cancellationToken);

        Task DenyRegistrationAsync(Guid registrationId, string reason, CancellationToken cancellationToken);

        Task AcceptPaymentAsync(AcceptPaymentRequest request, CancellationToken cancellationToken);

        Task AcceptCheckpointAsync(AcceptCheckpointRequest request, CancellationToken cancellationToken);

        Task<GetRacesForActionResponse> GetRacesForActionAsync(GetRacesForActionRequest request, CancellationToken cancellationToken);

        Task<GetResultsForActionResponse> GetResultsForActionAsync(GetResultsForActionRequest request, CancellationToken cancellationToken);

        Task<GetPublicActionsListResponse> GetPublicActionsListAsync(GetPublicActionsListRequest request, CancellationToken cancellationToken);
        
        Task<GetSelectedPublicActionsListResponse> GetSelectedPublicActionsListAsync(GetSelectedPublicActionsListRequest request, CancellationToken cancellationToken);
    }
}