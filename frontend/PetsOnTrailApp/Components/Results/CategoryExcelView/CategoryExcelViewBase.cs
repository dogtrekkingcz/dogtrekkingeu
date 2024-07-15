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

    public List<Competitor> competitorsData = new List<Competitor>(0);
    public List<Competitor> competitorsDataOrdered = new List<Competitor>(0);

    public class Competitor
    {
        public Guid Id { get; set; }
        public int? Order { get; set; } = 0;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Pets { get; set; } = string.Empty;
        public DateTimeOffset? Start { get; set; } = null;
        public DateTimeOffset? Checkpoint1 { get; set; } = null;
        public DateTimeOffset? Finish { get; set; } = null;
        public TimeSpan? ResultTime { get; set; } = null;

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

        var order = 0;
        foreach (var competitor in Model.Results)
        {
            competitorsData.Add(new Competitor
            {
                Id = competitor.Id,
                Order = order,
                FirstName = competitor.FirstName,
                LastName = competitor.LastName,
                Pets = string.Join(", ", competitor.Pets.Select(pet => pet)),
                Start = competitor.Start,
                Checkpoint1 = competitor.Checkpoints.Count > 0 ? competitor.Checkpoints[0].Time : null,
                Finish = competitor.Finish,
                ResultTime = competitor.Finish.HasValue ? competitor.Finish.Value.Subtract(competitor.Start.Value) : null
            });
        }

        competitorsDataOrdered = competitorsData
            .OrderBy(competitor => competitor.ResultTime ?? TimeSpan.MaxValue)
            .Select((competitor, index) => new Competitor {
                Id = competitor.Id,
                FirstName = competitor.FirstName,
                LastName = competitor.LastName,
                Pets = competitor.Pets,
                Start = competitor.Start,
                Checkpoint1 = competitor.Checkpoint1,
                Finish = competitor.Finish,
                ResultTime = competitor.ResultTime,
                Order = (competitor.ResultTime != null ? index + 1 : null)
            })
            .OrderBy(competitor => competitor.LastName)
            .ThenBy(competitor => competitor.FirstName)
            .ToList();

        StateHasChanged();
    }

    protected void Save(Competitor competitor)
    {
        // _actionsRepository.SaveResultsForActionRaceCategoryAsync(Guid.Parse(ActionId), Guid.Parse(RaceId), Guid.Parse(CategoryId), Model, CancellationToken.None);
    }
}
