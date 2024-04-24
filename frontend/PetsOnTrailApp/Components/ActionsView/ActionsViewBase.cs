using Microsoft.AspNetCore.Components;
using PetsOnTrailApp.DataStorage.Repositories.ActionsRepository;
using PetsOnTrailApp.Models;

namespace PetsOnTrailApp.Components.ActionsView;

public class ActionsViewBase : ComponentBase
{
    [Parameter] public string TypeId { get; set; }

    [Inject] private IActionsRepository _actionsRepository { get; set; }

    public IList<SimpleActionModel> Model = null;

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

        Model = await _actionsRepository.GetAllActionsByTypeAsync(Guid.Parse(TypeId));
    }
}
