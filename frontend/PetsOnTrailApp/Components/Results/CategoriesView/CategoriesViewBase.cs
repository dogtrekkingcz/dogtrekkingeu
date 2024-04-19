using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using PetsOnTrailApp.DataStorage;
using PetsOnTrailApp.Models;
using PetsOnTrailApp.Shared.ResourceFiles;

namespace PetsOnTrailApp.Components.Results.CategoriesView;

public class CategoriesViewBase : ComponentBase
{
    [Parameter] public string ActionId { get; set; } = string.Empty;
    [Parameter] public string RaceId { get; set; } = string.Empty;

    [Inject] private IDataStorageService _dataStorageService { get; set; }

    public CategoriesModel Model = null;

    protected override void OnInitialized()
    {
        base.OnInitialized();

        Model = _dataStorageService.GetCategoriesForActionRaceAsync(Guid.Parse(ActionId), Guid.Parse(RaceId)).Result;
    }
}
