using PetsOnTrail.Interfaces.Actions.Entities.Results;

namespace PetsOnTrail.Interfaces.Actions.Services;

public interface IResultsService
{
    Task<AddResultResponse> AddResultAsync(AddResultRequest request, CancellationToken cancellationToken);

    Task<AcceptResultResponse> AcceptResultAsync(AcceptResultRequest request, CancellationToken cancellationToken);
}