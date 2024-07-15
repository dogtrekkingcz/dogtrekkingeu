using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PetsOnTrailApp.DataStorage.Repositories.ActionsRepository;
using PetsOnTrailApp.Models;

namespace PetsOnTrailApp.Components.Results.CategoryExcelView;

public class CategoryExcelViewBase : ComponentBase
{
    [Parameter] public string ActionId { get; set; } = string.Empty;
    [Parameter] public string RaceId { get; set; } = string.Empty;
    [Parameter] public string CategoryId { get; set; } = string.Empty;

    [Inject] private IActionsRepository _actionsRepository { get; set; }
    [Inject] private NavigationManager _navigationManager { get; set; }
    [Inject] private IJSRuntime JSRuntime { get; set; }

    public ResultsModel Model { get; set; } = null;
    public RaceModel RaceModel { get; set; } = null;
    public bool CanIEditResults { get; set; } = false;

    public List<Competitor> tableData = new List<Competitor>
    {
        new Competitor { Start = DateTimeOffset.Now },
        new Competitor { Start = DateTimeOffset.Now },
        new Competitor { Start = DateTimeOffset.Now },
        new Competitor { Start = DateTimeOffset.Now },
        new Competitor { Start = DateTimeOffset.Now },
        new Competitor { Start = DateTimeOffset.Now },
        new Competitor { Start = DateTimeOffset.Now },
        new Competitor { Start = DateTimeOffset.Now },
        new Competitor { Start = DateTimeOffset.Now },
    };

    public class Competitor
    {
        public DateTimeOffset? Start { get; set; } = null;
    }


    protected async override Task OnInitializedAsync()
    {
        base.OnInitialized();

        CanIEditResults = await _actionsRepository.CanIEditResultsAsync(Guid.Parse(ActionId), CancellationToken.None);

        await Reload(false);
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await JSRuntime.InvokeVoidAsync("initializeNumpad", DotNetObjectReference.Create(this));
            await Task.Delay(100); // Add a delay to ensure inputs are rendered
        }
    }

    private async Task Reload(bool forceReloadFromServerStorage)
    {
        Model = await _actionsRepository.GetResultsForActionRaceCategoryAsync(Guid.Parse(ActionId), Guid.Parse(RaceId), Guid.Parse(CategoryId), forceReloadFromServerStorage);
        RaceModel = await _actionsRepository.GetRaceForActionAsync(Guid.Parse(ActionId), Guid.Parse(RaceId), CancellationToken.None);

        StateHasChanged();
    }
}
