using MapsterMapper;
using Microsoft.AspNetCore.Components;
using PetsOnTrailApp.Components.ResultsAdd;
using Protos.Actions.GetResultsForAction;
using SharedLib.Models;
using static Protos.Actions.Actions;

namespace PetsOnTrailApp.Components.Results.Results;

public class ResultsBase : ComponentBase
{
    [Parameter]
    public string ActionId { get; set; }

    [Inject]
    private ActionsClient _actionsClient { get; set; }

    [Inject]
    private IMapper _mapper { get; set; }


    public ActionResultsModel Model = null;
    public ActionModel Action = null;

    protected override async Task OnInitializedAsync()
    {
        var selectedActions = await _actionsClient.getSelectedPublicActionsListAsync(
            new Protos.Actions.GetSelectedPublicActionsList.GetSelectedPublicActionsListRequest() { Ids = { ActionId } });

        if ((selectedActions?.Actions?.Count ?? 0) != 0)
        {
            Action = _mapper.Map<ActionModel>(selectedActions.Actions[0]);
            await ReloadData();
        }

        // no loading data if action is not found
    }

    public async Task ReloadData()
    {
        var response = await _actionsClient.getResultsForActionAsync(new GetResultsForActionRequest() { ActionId = ActionId });

        Model = _mapper.Map<ActionResultsModel>(response);

        StateHasChanged();
    }

    public void ResultAdded(string actionId, Guid raceId, Guid categoryId, ResultAddModel model)
    {
        Model
            .Races.FirstOrDefault(r => r.Id == raceId)?
            .Categories.FirstOrDefault(c => c.Id == categoryId)?
            .Racers.Add(_mapper.Map<ActionResultsModel.RacerResultDto>(model));

        StateHasChanged();
    }
}
