using Microsoft.AspNetCore.Components;
using PetsOnTrailApp.DataStorage.Repositories.ActionsRepository;
using PetsOnTrailApp.Models;

namespace PetsOnTrailApp.Components.ActionViewHeader;

public class ActionViewHeaderBase : ComponentBase
{
    [Parameter] public string ActionId { get; set; }
    [Parameter] public string RaceId { get; set; }
    [Parameter] public string CategoryId { get; set; }

    [Inject] private IActionsRepository _actionsRepository { get; set; }
    [Inject] private NavigationManager Navigation { get; set; }
    
    public SimpleActionModel Model = null;

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

        Model = await _actionsRepository.GetSimpleActionModelAsync(Guid.Parse(ActionId), CancellationToken.None);
    }

    protected void NavigateToActions() => Navigation.NavigateTo($"/actions");

    protected void NavigateToAction() => Navigation.NavigateTo($"/action/{ActionId}");

    protected void NavigateToRaces() => Navigation.NavigateTo($"/races/{ActionId}");

    protected void NavigateToRace() => Navigation.NavigateTo($"/race/{ActionId}/{RaceId}");

    protected void NavigateToCategories() => Navigation.NavigateTo($"/categories/{ActionId}/{RaceId}");

    protected void NavigateToCategory() => Navigation.NavigateTo($"/category/{ActionId}/{RaceId}/{CategoryId}");
}
