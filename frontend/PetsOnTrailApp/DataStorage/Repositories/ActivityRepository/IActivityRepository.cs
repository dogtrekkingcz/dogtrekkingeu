using PetsOnTrailApp.Models;

namespace PetsOnTrailApp.DataStorage.Repositories.ActivityRepository;

public interface IActivityRepository
{
    Task<ActivityModel> GetActivityByUserIdAndActivityId(Protos.Activities.UserIdAndActivityId userIdAndActivityId, CancellationToken cancellationToken);
    Task<UserActivitiesModel> GetActivitiesByUserId(Protos.Activities.UserIdRequest userIdRequest, CancellationToken cancellationToken);
}
