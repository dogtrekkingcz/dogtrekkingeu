using FisSst.BlazorMaps;
using Microsoft.AspNetCore.Components;
using PetsOnTrailApp.DataStorage.Repositories.ActivityRepository;
using PetsOnTrailApp.Models;

namespace PetsOnTrailApp.Components.ActivityView;

public class UserActivitiesViewBase : ComponentBase
{
    [Parameter] public string UserId { get; set; }

    [Inject] private IActivityRepository _activityRepository { get; set; }
    [Inject] private NavigationManager Navigation { get; set; }

    public ActivityModel Model = null;

    protected async override void OnInitialized()
    {
        base.OnInitialized();

        Model = await _activityRepository.GetActivitiesByUserId(new Protos.Activities.UserIdRequest { UserId = UserId }, CancellationToken.None);

        StateHasChanged();
    }

    protected async Task LoadAsync()
    {
        StateHasChanged();
    }
}
