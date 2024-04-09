using PetsOnTrail.Interfaces.Actions.Entities.Checkpoints;

namespace PetsOnTrail.Interfaces.Actions.Services;

public interface ICheckpointsService
{
    Task<AddCheckpointItemResponse> AddAsync(AddCheckpointItemRequest request, CancellationToken cancellationToken);

    Task<GetCheckpointItemsResponse> GetAsync(GetCheckpointItemsRequest request, CancellationToken cancellationToken);
}