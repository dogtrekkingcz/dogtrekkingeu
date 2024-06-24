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
        Model = await _actionsRepository.GetResultsForActionRaceCategoryAsync(Guid.Parse(ActionId), Guid.Parse(RaceId), Guid.Parse(CategoryId), forceReloadFromServerStorage);

        StateHasChanged();
    }

    public void EditStart(Guid racerId)
    {
        // TODO: Implement
    }

    public void EditFinish(Guid racerId)
    {
        // TODO: Implement
    }

    public void StartNow(Guid racerId)
    {
        _actionsRepository.StartNow(Guid.Parse(ActionId), Guid.Parse(RaceId), Guid.Parse(CategoryId), racerId);
        Reload(true);
    }

    public void FinishNow(Guid racerId)
    {
        _actionsRepository.FinishNow(Guid.Parse(ActionId), Guid.Parse(RaceId), Guid.Parse(CategoryId), racerId);
        Reload(true);
    }

    public void DeleteStart(Guid racerId)
    {
        _actionsRepository.DeleteStart(Guid.Parse(ActionId), Guid.Parse(RaceId), Guid.Parse(CategoryId), racerId);
        Reload(true);
    }

    public void DeleteFinish(Guid racerId)
    {
        _actionsRepository.DeleteFinish(Guid.Parse(ActionId), Guid.Parse(RaceId), Guid.Parse(CategoryId), racerId);
        Reload(true);
    }

    public void Dns(Guid racerId)
    {
        _actionsRepository.Dns(Guid.Parse(ActionId), Guid.Parse(RaceId), Guid.Parse(CategoryId), racerId);
        Reload(true);
    }

    public void Dnf(Guid racerId)
    {
        _actionsRepository.Dnf(Guid.Parse(ActionId), Guid.Parse(RaceId), Guid.Parse(CategoryId), racerId);
        Reload(true);
    }

    public void Dsq(Guid racerId)
    {
        _actionsRepository.Dsq(Guid.Parse(ActionId), Guid.Parse(RaceId), Guid.Parse(CategoryId), racerId);
        Reload(true);
    }

    public void ResetStates(Guid racerId)
    {
        _actionsRepository.ResetStates(Guid.Parse(ActionId), Guid.Parse(RaceId), Guid.Parse(CategoryId), racerId);
        Reload(true);
    }
}
