using DogsOnTrail.Interfaces.Actions.Entities.Activities;

namespace DogsOnTrail.Interfaces.Actions.Services;

public interface IActivitiesService
{
    Task<CreateActivityResponse> CreateActivityAsync(CreateActivityRequest request, CancellationToken cancellationToken);

    Task<AddPointResponse> AddPointAsync(AddPointRequest request, CancellationToken cancellationToken);
    
    Task<GetMyActivitiesResponse> GetMyActivitiesAsync(GetMyActivitiesRequest request, CancellationToken cancellationToken);
}