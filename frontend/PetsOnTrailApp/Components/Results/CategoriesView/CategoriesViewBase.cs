using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Microsoft.Maui.Controls;
using PetsOnTrailApp.DataStorage.Repositories.ActionsRepository;
using PetsOnTrailApp.Models;

namespace PetsOnTrailApp.Components.Results.CategoriesView;

public class CategoriesViewBase : ComponentBase
{
    [Parameter] public string ActionId { get; set; } = string.Empty;
    [Parameter] public string RaceId { get; set; } = string.Empty;

    [Inject] private IActionsRepository _actionsRepository { get; set; }
    [Inject] private NavigationManager Navigation { get; set; }

    public CategoriesModel Model = null;

    protected async override void OnInitialized()
    {
        base.OnInitialized();

        Model = await _actionsRepository.GetCategoriesForActionRaceAsync(Guid.Parse(ActionId), Guid.Parse(RaceId));
    }

    protected void NavigateToCategoryOf(Guid categoryId)
    {
        Navigation.NavigateTo($"category/{ActionId}/{RaceId}/{categoryId.ToString()}");
    }
}
