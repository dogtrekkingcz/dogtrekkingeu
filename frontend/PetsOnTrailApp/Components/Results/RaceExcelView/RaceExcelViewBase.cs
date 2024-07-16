using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PetsOnTrailApp.DataStorage.Repositories.ActionsRepository;
using PetsOnTrailApp.Models;

namespace PetsOnTrailApp.Components.Results.RaceExcelView;

public class RaceExcelViewBase : ComponentBase
{
    [Parameter] public string ActionId { get; set; } = string.Empty;
    [Parameter] public string RaceId { get; set; } = string.Empty;

    [Inject] private IActionsRepository _actionsRepository { get; set; }
    [Inject] private NavigationManager _navigationManager { get; set; }
    [Inject] private IJSRuntime JSRuntime { get; set; }

    public ResultsModel Model { get; set; } = null;
    public RaceModel RaceModel { get; set; } = null;
    public bool CanIEditResults { get; set; } = false;

    public List<Competitor> competitorsDataOrdered = new List<Competitor>(0);

    private bool _orderByOrderDescending = false;
    private bool _orderBySurnameNameDescending = false;
    private bool _orderByStartDescending = false;
    private bool _orderByCheckpointDescending = false;
    private bool _orderByFinishDescending = false;

    public class Competitor
    {
        public Guid Id { get; set; }
        public int? Order { get; set; } = 0;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
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
        RaceModel = await _actionsRepository.GetRaceForActionAsync(Guid.Parse(ActionId), Guid.Parse(RaceId), CancellationToken.None);
        Model = await _actionsRepository.GetResultsForActionRaceAsync(Guid.Parse(ActionId), Guid.Parse(RaceId), forceReloadFromServerStorage);


        var order = 0;
        foreach (var competitor in Model.Results)
        {
            competitorsDataOrdered.Add(new Competitor
            {
                Id = competitor.Id,
                Order = order,
                FirstName = competitor.FirstName,
                LastName = competitor.LastName,
                Pets = string.Join(", ", competitor.Pets.Select(pet => pet)),
                Start = competitor.Start,
                Checkpoint1 = competitor.Checkpoints.Count > 0 ? competitor.Checkpoints[0].Time : null,
                Finish = competitor.Finish,
                ResultTime = competitor.Finish.HasValue ? competitor.Finish.Value.Subtract(competitor.Start.Value) : null,
                Category = competitor.Category
            });
        }

        SortThemAllAndFillTheOrder();

        StateHasChanged();
    }

    private void SortThemAllAndFillTheOrder()
    {
        competitorsDataOrdered = competitorsDataOrdered
            .OrderBy(competitor => competitor.ResultTime ?? TimeSpan.MaxValue)
            .ToList();

        for (int i = 0; i < competitorsDataOrdered.Count; i++)
        {
            if (competitorsDataOrdered[i].ResultTime != null)
            {
                competitorsDataOrdered[i].Order = i + 1;
            }
        }

        competitorsDataOrdered = competitorsDataOrdered
            .OrderBy(competitor => competitor.LastName)
            .ThenBy(competitor => competitor.FirstName)
            .ToList();
    }

    protected void SortByOrder()
    {
        if (_orderByOrderDescending)
        {
            competitorsDataOrdered = competitorsDataOrdered
                .OrderByDescending(competitor => competitor.Order)
                .ToList();
        }
        else
        {
            competitorsDataOrdered = competitorsDataOrdered
            .OrderBy(competitor => competitor.Order)
            .ToList();
        }

        _orderByOrderDescending = !_orderByOrderDescending;
        

        StateHasChanged();
    }

    protected void SortBySurnameName()
    {
        if (_orderBySurnameNameDescending)
        {
            competitorsDataOrdered = competitorsDataOrdered
                .OrderByDescending(competitor => competitor.LastName)
                .ThenBy(competitor => competitor.FirstName)
                .ToList();
        }
        else
        {
            competitorsDataOrdered = competitorsDataOrdered
                .OrderBy(competitor => competitor.LastName)
                .ThenBy(competitor => competitor.FirstName)
                .ToList();
        }

        _orderBySurnameNameDescending = !_orderBySurnameNameDescending;
    }

    protected void SortByStart()
    {
        if (_orderByStartDescending)
        {
            competitorsDataOrdered = competitorsDataOrdered
                .OrderByDescending(competitor => competitor.Start)
                .ToList();
        }
        else
        {
            competitorsDataOrdered = competitorsDataOrdered
                .OrderBy(competitor => competitor.Start)
                .ToList();
        }

        _orderByStartDescending = !_orderByStartDescending;
    }

    protected void SortByCheckpoint()
    {
        if (_orderByCheckpointDescending)
        {
            competitorsDataOrdered = competitorsDataOrdered
                .OrderByDescending(competitor => competitor.Checkpoint1)
                .ToList();
        }
        else
        {
            competitorsDataOrdered = competitorsDataOrdered
                .OrderBy(competitor => competitor.Checkpoint1)
                .ToList();
        }

        _orderByCheckpointDescending = !_orderByCheckpointDescending;
    }

    protected void SortByFinish()
    {
        if (_orderByFinishDescending)
        {
            competitorsDataOrdered = competitorsDataOrdered
                .OrderByDescending(competitor => competitor.Finish)
                .ToList();
        }
        else
        {
            competitorsDataOrdered = competitorsDataOrdered
                .OrderBy(competitor => competitor.Finish)
                .ToList();
        }

        _orderByFinishDescending = !_orderByFinishDescending;
    }

    protected void OnTimeUpdateFinish(Competitor competitor, DateTimeOffset? value)
    {
        if (value.HasValue)
        {
            competitor.Finish = value;
            competitor.ResultTime = competitor.Finish.Value.Subtract(competitor.Start.Value);
        }
        else
        {
            competitor.Finish = null;
            competitor.ResultTime = null;
        }

        SortThemAllAndFillTheOrder();

        StateHasChanged();
    }

    protected void OnTimeUpdateStart(Competitor competitor, DateTimeOffset? value)
    {
        if (value.HasValue)
        {
            competitor.Start = value;

            if (competitor.Finish.HasValue)
            {
                competitor.ResultTime = competitor.Finish.Value.Subtract(competitor.Start.Value);
            }
        }
        else
        {
            competitor.Start = null;
            competitor.ResultTime = null;
        }

        SortThemAllAndFillTheOrder();

        StateHasChanged();
    }

    protected void Save(Competitor competitor)
    {
        // _actionsRepository.SaveResultsForActionRaceCategoryAsync(Guid.Parse(ActionId), Guid.Parse(RaceId), Guid.Parse(CategoryId), Model, CancellationToken.None);
    }
}
