using Microsoft.AspNetCore.Components;
using PetsOnTrailApp.DataStorage;
using PetsOnTrailApp.DataStorage.Repositories.ActionsRepository;
using PetsOnTrailApp.Models;

namespace PetsOnTrailApp.Components.Results.CategoryView;

public class CategoryViewBase : ComponentBase
{
    [Parameter] public string ActionId { get; set; } = string.Empty;
    [Parameter] public string RaceId { get; set; } = string.Empty;
    [Parameter] public string CategoryId { get; set; } = string.Empty;

    [Inject] private IActionsRepository _actionsRepository { get; set; }

    public ResultsModel Model { get; set; } = null;
    public bool CanIEditResults { get; set; } = false;

    protected async override Task OnInitializedAsync()
    {
        base.OnInitialized();

        CanIEditResults = await _actionsRepository.CanIEditResultsAsync(Guid.Parse(ActionId), CancellationToken.None);

        await Reload(false);
    }

    private async Task Reload(bool forceReloadFromServerStorage)
    {
        Console.WriteLine("Reloading results for action ");
        Model = await _actionsRepository.GetResultsForActionRaceCategoryAsync(Guid.Parse(ActionId), Guid.Parse(RaceId), Guid.Parse(CategoryId), forceReloadFromServerStorage);
        Console.WriteLine("Results reloaded");

        Console.WriteLine("Starting refreshing UI");
        StateHasChanged();
        Console.WriteLine("UI refreshed");
    }

    public async Task EditStart(Guid racerId)
    {
        // TODO: Implement
    }

    public async Task EditFinish(Guid racerId)
    {
        // TODO: Implement
    }

    public async Task StartNow(Guid racerId)
    {
        await _actionsRepository.StartNow(Guid.Parse(ActionId), Guid.Parse(RaceId), Guid.Parse(CategoryId), racerId);
        await Reload(true);
    }

    public async Task FinishNow(Guid racerId)
    {
        await _actionsRepository.FinishNow(Guid.Parse(ActionId), Guid.Parse(RaceId), Guid.Parse(CategoryId), racerId);
        await Reload(true);
    }

    public async Task DeleteStart(Guid racerId)
    {
        await _actionsRepository.DeleteStart(Guid.Parse(ActionId), Guid.Parse(RaceId), Guid.Parse(CategoryId), racerId);
        await Reload(true);
    }

    public async Task DeleteFinish(Guid racerId)
    {
        await _actionsRepository.DeleteFinish(Guid.Parse(ActionId), Guid.Parse(RaceId), Guid.Parse(CategoryId), racerId);
        await Reload(true);
    }

    public async Task Dns(Guid racerId)
    {
        await _actionsRepository.Dns(Guid.Parse(ActionId), Guid.Parse(RaceId), Guid.Parse(CategoryId), racerId);
        await Reload(true);
    }

    public async Task Dnf(Guid racerId)
    {
        await _actionsRepository.Dnf(Guid.Parse(ActionId), Guid.Parse(RaceId), Guid.Parse(CategoryId), racerId);
        await Reload(true);
    }

    public async Task Dsq(Guid racerId)
    {
        await _actionsRepository.Dsq(Guid.Parse(ActionId), Guid.Parse(RaceId), Guid.Parse(CategoryId), racerId);
        await Reload(true);
    }

    public async Task ResetStates(Guid racerId)
    {
        await _actionsRepository.ResetStates(Guid.Parse(ActionId), Guid.Parse(RaceId), Guid.Parse(CategoryId), racerId);
        await Reload(true);
    }
}
