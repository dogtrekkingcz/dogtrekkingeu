using PetsOnTrail.Interfaces.Actions.Entities.Activities;

namespace PetsOnTrail.Interfaces.Actions.Services;

public interface IActivitiesService
{
    Task<CreateActivityResponse> CreateActivityAsync(CreateActivityRequest request, CancellationToken cancellationToken);

    Task<AddPointResponse> AddPointAsync(AddPointRequest request, CancellationToken cancellationToken);
    
    Task<GetMyActivitiesResponse> GetMyActivitiesAsync(GetMyActivitiesRequest request, CancellationToken cancellationToken);

    Task<GetActivitiesResponse> GetActivitiesAsync(CancellationToken cancellationToken);

    Task<UpdateActivityResponse> UpdateActivityAsync(UpdateActivityRequest request, CancellationToken cancellationToken);
}