using Microsoft.AspNetCore.Components;
using PetsOnTrailApp.DataStorage.Repositories.ActionsRepository;
using PetsOnTrailApp.Models;

namespace PetsOnTrailApp.Components.ActionView;

public class ActionViewBase : ComponentBase
{
    [Parameter] public string ActionId { get; set; }

    [Inject] private IActionsRepository _actionsRepository { get; set; }
    [Inject] private NavigationManager Navigation { get; set; }

    public ActionModel Model = null;

    protected async override void OnInitialized()
    {
        base.OnInitialized();

        Model = await _actionsRepository.GetActionModelAsync(Guid.Parse(ActionId), CancellationToken.None);
    }

    protected void NavigateToRaces() => Navigation.NavigateTo("/races/{ActionId}");
}
