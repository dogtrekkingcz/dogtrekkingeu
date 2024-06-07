using Microsoft.AspNetCore.Components;
using PetsOnTrailApp.DataStorage.Repositories.ActivityRepository;
using PetsOnTrailApp.Models;

namespace PetsOnTrailApp.Components.UserActivitiesView;

public class UserActivitiesViewBase : ComponentBase
{
    [Parameter] public string UserId { get; set; }

    [Inject] private IActivityRepository _activityRepository { get; set; }
    [Inject] private NavigationManager Navigation { get; set; }

    public UserActivitiesModel Model = null;

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

    protected void NavigateToActivity(string activityId)
    {
        Navigation.NavigateTo($"/activity/{UserId}/{activityId}");
    }
}
