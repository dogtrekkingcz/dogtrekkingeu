using Microsoft.AspNetCore.Components;
using PetsOnTrailApp.DataStorage.Repositories.ActionsRepository;
using PetsOnTrailApp.Models;

namespace PetsOnTrailApp.Components.Results.RacesView;

public class RacesViewBase : ComponentBase
{
    [Parameter] public string ActionId { get; set; }

    [Inject] private IActionsRepository _actionsRepository { get; set; }
    [Inject] private NavigationManager Navigation { get; set; }

    public RacesModel Model = null;

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

        Model = await _actionsRepository.GetRacesForActionAsync(Guid.Parse(ActionId));
    }

    protected void NavigateToCategoriesOf(Guid raceId)
    {
        Navigation.NavigateTo($"categories/{ActionId}/{raceId}");
    }
}
