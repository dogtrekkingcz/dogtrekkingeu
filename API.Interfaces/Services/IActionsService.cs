using PetsOnTrail.Interfaces.Actions.Entities;
using PetsOnTrail.Interfaces.Actions.Entities.Actions;
using PetsOnTrail.Interfaces.Actions.Entities.Results;
using System.Net;
using System.Security.Cryptography;

namespace PetsOnTrail.Interfaces.Actions.Services
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

        Task<GetSimpleActionsListByTypeResponse> GetSimpleActionsListByTypeAsync(IList<Guid> typeIds, CancellationToken cancellationToken);

        Task<StartNowResponse> StartNowAsync(StartNowRequest request, CancellationToken cancellationToken);
        Task<FinishNowResponse> FinishNowAsync(FinishNowRequest request, CancellationToken cancellationToken);
        Task<DeleteStartResponse> DeleteStartAsync(DeleteStartRequest request, CancellationToken cancellationToken);
        Task<DeleteFinishResponse> DeleteFinishAsync(DeleteFinishRequest request, CancellationToken cancellationToken);
        Task<DnsResponse> DnsAsync(DnsRequest request, CancellationToken cancellationToken);
        Task<DsqResponse> DsqAsync(DsqRequest request, CancellationToken cancellationToken);
        Task<DnfResponse> DnfAsync(DnfRequest request, CancellationToken cancellationToken);
        Task<ResetStatesResponse> ResetStatesAsync(ResetStatesRequest request, CancellationToken cancellationToken);
    }
}