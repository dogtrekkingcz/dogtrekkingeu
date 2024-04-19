using Microsoft.AspNetCore.Components;
using PetsOnTrailApp.DataStorage;
using PetsOnTrailApp.Models;

namespace PetsOnTrailApp.Components.Results.RacesView;

public class RacesViewBase : ComponentBase
{
    [Parameter] public string ActionId { get; set; }

    [Inject] private IDataStorageService _dataStorageService { get; set; }


    public RacesModel Model = null;

    protected override async Task OnInitializedAsync()
    {
        base.OnInitializedAsync();

        Model = await _dataStorageService.GetRacesForActionAsync(Guid.Parse(ActionId));
    }
}
