using DogsOnTrail.Interfaces.Actions.Entities.Results;

namespace DogsOnTrail.Interfaces.Actions.Services;

public interface IResultsService
{
    Task<AddResultResponse> AddResultAsync(AddResultRequest request, CancellationToken cancellationToken);

    Task<AcceptResultResponse> AcceptResultAsync(AcceptResultRequest request, CancellationToken cancellationToken);
}