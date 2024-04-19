using Microsoft.AspNetCore.Components;
using PetsOnTrailApp.DataStorage;
using PetsOnTrailApp.Models;

namespace PetsOnTrailApp.Components.Results.CategoryView;

public class ResultsCategoryViewBase : ComponentBase
{
    [Parameter] public string ActionId { get; set; } = string.Empty;
    [Parameter] public string RaceId { get; set; } = string.Empty;
    [Parameter] public string CategoryId { get; set; } = string.Empty;

    [Inject] private IDataStorageService _storageService { get; set; }

    public ResultsModel Model { get; set; } = null;

    protected async override Task OnInitializedAsync()
    {
        base.OnInitialized();

        Model = await _storageService.GetResultsForActionRaceCategoryAsync(Guid.Parse(ActionId), Guid.Parse(RaceId), Guid.Parse(CategoryId));
    }
}
