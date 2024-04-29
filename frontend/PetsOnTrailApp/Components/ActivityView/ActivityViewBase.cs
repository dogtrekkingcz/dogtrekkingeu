using Microsoft.AspNetCore.Components;
using PetsOnTrailApp.DataStorage.Repositories.ActivityRepository;
using PetsOnTrailApp.Models;

namespace PetsOnTrailApp.Components.ActivityView;

public class ActivityViewBase : ComponentBase
{
    [Parameter] public string UserId { get; set; }
    [Parameter] public string ActivityId { get; set; }

    [Inject] private IActivityRepository _activityRepository { get; set; }
    [Inject] private NavigationManager Navigation { get; set; }

    public ActivityModel Model = null;

    protected async override void OnInitialized()
    {
        base.OnInitialized();

        Model = await _activityRepository.GetActivityByUserIdAndActivityId(new Protos.Activities.UserIdAndActivityId { UserId = UserId, ActivityId = ActivityId }, CancellationToken.None);
    }
}
