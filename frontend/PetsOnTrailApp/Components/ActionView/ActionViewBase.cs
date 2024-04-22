using Microsoft.AspNetCore.Components;
using PetsOnTrailApp.DataStorage.Repositories.ActionsRepository;
using PetsOnTrailApp.Models;

namespace PetsOnTrailApp.Components.ActionView;

public class ActionViewBase : ComponentBase
{
    [Parameter] public string ActionId { get; set; }

    [Inject] private IActionsRepository _actionsRepository { get; set; }
    
    public ActionModel Model = null;

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

        Model = await _actionsRepository.GetActionModelAsync(Guid.Parse(ActionId));
    }
}
