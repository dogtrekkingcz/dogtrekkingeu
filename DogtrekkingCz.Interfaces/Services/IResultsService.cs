using DogtrekkingCz.Interfaces.Actions.Entities.Results;
using DogtrekkingCzShared.Entities;

namespace DogtrekkingCz.Interfaces.Actions.Services;

public interface IResultsService
{
    Task<AddResultResponse> AddResultAsync(AddResultRequest request, CancellationToken cancellationToken);

    Task<AcceptResultResponse> AcceptResultAsync(AcceptResultRequest request, CancellationToken cancellationToken);

    Task<List<RaceDto>> GetRacesForAction(GetRacesForActionRequest request, CancellationToken cancellationToken);
}