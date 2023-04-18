using DogtrekkingCz.Interfaces.Actions.Entities.Rights;
using DogtrekkingCz.Interfaces.Actions.Services;

namespace DogtrekkingCz.Actions.Services.Rights;

internal sealed class RightsService : IRightsService
{
    public Task<GetAllRightsResponse> GetAllRightsAsync(GetAllRightsRequest request, CancellationToken cancellationToken)
    {
        return Task.FromResult(new GetAllRightsResponse
        {

        });
    }
}