using Microsoft.AspNetCore.Components;
using System.Text.RegularExpressions;
using static Protos.Results.Results;
using MapsterMapper;
using PetsOnTrailApp.Models;
using PetsOnTrailApp.DataStorage.Repositories.ActionsRepository;

namespace PetsOnTrailApp.Components.Results.ResultsAdd;

public class ResultsAddBase : ComponentBase
{
    [Parameter] public string ActionId { get; set; }
    [Parameter] public string RaceId { get; set; }
    [Parameter] public string CategoryId { get; set; }
    [Parameter] public EventCallback? OnResultAddedCallback { get; set; } = null;

    [Inject] private ResultsClient _resultsClient { get; set; }
    [Inject] private IActionsRepository _actionsRepository { get; set; }
    [Inject] private IMapper _mapper { get; set; }
    [Inject] private NavigationManager NavigationManager { get; set; }


    protected ResultsModel.ResultDto Model = new();

    protected string WholeTime { get; set; } = string.Empty;
    protected string _pets { get; set; } = string.Empty;

    protected DateTimeOffset Start { get; set; }
    protected DateTimeOffset Finish { get; set; }

    protected ResultsModel.ResultState State { get; set; } = ResultsModel.ResultState.NotValid;

    protected bool IsStartShown => (new List<ResultsModel.ResultState>()
                                    {
                                        ResultsModel.ResultState.Started,
                                        ResultsModel.ResultState.Finished,
                                        ResultsModel.ResultState.DidNotFinished,
                                        ResultsModel.ResultState.Disqualified
                                    }).Contains(Model.State);

    protected bool IsFinishShown => (new List<ResultsModel.ResultState>()
    {
        ResultsModel.ResultState.Finished,
    }).Contains(Model.State);

    protected override async Task OnInitializedAsync()
    {
        var race = await _actionsRepository.GetRaceForActionAsync(Guid.Parse(ActionId), Guid.Parse(RaceId), CancellationToken.None);

        if (race != null && race.Data != null)
        { 
            Start = race.Data.Begin;
            Finish = race.Data.End;
        }
    }

    protected async Task OnFormValid()
    {
    }

    protected async Task OnFormInvalid()
    {

    }

    protected void StartIsFilled(Microsoft.AspNetCore.Components.Web.FocusEventArgs args)
    {
        Console.WriteLine($"StartIsFilled with value: {Start}");

        Model.Start = Start;

        StartAndFinishIsFilledCountResult();
    }

    protected void FinishIsFilled(Microsoft.AspNetCore.Components.Web.FocusEventArgs args)
    {
        Console.WriteLine($"FinishIsFilled with value: {Finish}");

        Model.Finish = Finish;

        StartAndFinishIsFilledCountResult();
    }

    protected void StartAndFinishIsFilledCountResult()
    {
        Console.WriteLine("StartAndFinishIsFilledCountResult");

        if (Model.Start.HasValue && Model.Finish.HasValue)
        {
            Console.WriteLine("StartAndFinishIsFilledCountResult - both filled");

            var diff = Model.Finish.Value.Subtract(Model.Start.Value);
            var hours = diff.TotalHours;

            diff -= TimeSpan.FromHours(hours);
            var minutes = diff.TotalMinutes;

            diff -= TimeSpan.FromMinutes(minutes);
            var seconds = diff.TotalSeconds;

            Console.WriteLine($"Hours: {hours}, Minutes: {minutes}, Seconds: {seconds}");
            WholeTime = $"{hours}:{minutes}:{seconds}";

            StateHasChanged();
        }
    }

    protected void PetsChanged(string pets)
    {
        if (string.IsNullOrWhiteSpace(pets))
        {
            Model.Pets = new List<string>();
            return;
        }

        var petsArray = pets.Split(new char[] { ',', ':', '.' });

        Model.Pets = petsArray
                        .ToList();
    }

    protected void RaceStateChanged(ResultsModel.ResultState state)
    {
        State = state;
        Model.State = state;

        StateHasChanged();
    }

    protected void WholeTimeChanged(string val)
    {
        int hours = 0, minutes = 0, seconds = 0;

        if (Regex.IsMatch(val, "^[a-zA-Z0-9,.:]+$") == false)
            return;

        string[] split = val.Split(new Char[] { ',', ':', '.' });
        switch (split.Length)
        {
            case 3: // hh:mm:ss
                hours = int.Parse(split[0]);
                minutes = int.Parse(split[1]);
                seconds = int.Parse(split[2]);
                break;

            case 2: // hh:mm
                hours = int.Parse(split[0]);
                minutes = int.Parse(split[1]);
                break;

            case 1: // hh
                hours = int.Parse(split[0]);
                break;

            default:
                break;
        }

        Model.Start = Start;
        Model.Finish = Start.AddHours(hours).AddMinutes(minutes).AddSeconds(seconds);

        StateHasChanged();
    }

    public void Cancel()
    {
        NavigationManager.NavigateTo($"/category/{ActionId}/{RaceId}/{CategoryId}");
    }
}
