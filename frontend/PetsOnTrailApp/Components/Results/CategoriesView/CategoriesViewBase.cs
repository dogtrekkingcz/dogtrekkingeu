using Microsoft.AspNetCore.Components;
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

    public bool CanIEditResults { get; set; } = false;

    public Dictionary<Guid, ResultsModel> Results { get; set; } = new Dictionary<Guid, ResultsModel>();

    protected async override void OnInitialized()
    {
        base.OnInitialized();

        Model = await _actionsRepository.GetCategoriesForActionRaceAsync(Guid.Parse(ActionId), Guid.Parse(RaceId));

        CanIEditResults = await _actionsRepository.CanIEditResultsAsync(Guid.Parse(ActionId), CancellationToken.None);

        await Reload(false);
    }

    public async Task StartNow(Guid categoryId, Guid racerId)
    {
        await _actionsRepository.StartNow(Guid.Parse(ActionId), Guid.Parse(RaceId), categoryId, racerId);
        await Reload(true);
    }

    public async Task FinishNow(Guid categoryId, Guid racerId)
    {
        await _actionsRepository.FinishNow(Guid.Parse(ActionId), Guid.Parse(RaceId), categoryId, racerId);
        await Reload(true);
    }

    protected void NavigateToCategoryOf(Guid categoryId)
    {
        Navigation.NavigateTo($"category/{ActionId}/{RaceId}/{categoryId}");
    }

    private async Task Reload(bool forceReloadFromServerStorage)
    {
        foreach (var category in Model.Categories)
        {
            Results[category.Id] = await _actionsRepository.GetResultsForActionRaceCategoryAsync(Guid.Parse(ActionId), Guid.Parse(RaceId), category.Id, forceReloadFromServerStorage);
        }

        StateHasChanged();
    }
}
