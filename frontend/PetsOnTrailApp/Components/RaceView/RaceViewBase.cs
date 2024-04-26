using Microsoft.AspNetCore.Components;
using PetsOnTrailApp.DataStorage.Repositories.ActionsRepository;
using PetsOnTrailApp.Models;

namespace PetsOnTrailApp.Components.RaceView;

public class RaceViewBase : ComponentBase
{
    [Parameter] public string ActionId { get; set; }
    [Parameter] public string RaceId { get; set; }

    [Inject] private IActionsRepository _actionsRepository { get; set; }
    [Inject] private NavigationManager Navigation { get; set; }

    public RaceModel Model = null;

    protected async override void OnInitialized()
    {
        base.OnInitialized();

        Model = await _actionsRepository.GetRaceForActionAsync(Guid.Parse(ActionId), Guid.Parse(RaceId), CancellationToken.None);
    }

    protected void NavigateToCategories() =>  Navigation.NavigateTo($"/categories/{ActionId}/{RaceId}");
}
