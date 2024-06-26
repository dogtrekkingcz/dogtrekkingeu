using Microsoft.AspNetCore.Components;
using System.Text.RegularExpressions;
using static Protos.Results.Results;
using MapsterMapper;
using PetsOnTrailApp.Models;
using PetsOnTrailApp.DataStorage.Repositories.ActionsRepository;
using PetsOnTrailApp.Extensions;

namespace PetsOnTrailApp.Components.Results.ResultsAdd;

public class ResultsAddBase : ComponentBase
{
    [Parameter] public string ActionId { get; set; }
    [Parameter] public string RaceId { get; set; }
    [Parameter] public string CategoryId { get; set; }
    [Parameter] public string RacerId { get; set; } = null;
    [Parameter] public EventCallback? OnResultAddedCallback { get; set; } = null;

    [Inject] private ResultsClient _resultsClient { get; set; }
    [Inject] private IActionsRepository _actionsRepository { get; set; }
    [Inject] private IMapper _mapper { get; set; }
    [Inject] private NavigationManager NavigationManager { get; set; }


    protected ResultsModel.ResultDto Model = new();

    protected string WholeTime { get; set; } = string.Empty;
    protected string _pets { get; set; } = string.Empty;
    
    protected DateTimeOffset Start { get; set; }
    protected Dictionary<Guid, DateTimeOffset> Checkpoints = new Dictionary<Guid, DateTimeOffset>();
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

            if (Model.Checkpoints.Count == 0 && race.Data.Checkpoints.Count > 0)
            { 
                Model.Checkpoints = race.Data.Checkpoints.Select(checkpoint => new ResultsModel.CheckpointDto()
                {
                    Id = checkpoint.Id,
                    Name = checkpoint.Name
                }).ToList();
            }

            Console.WriteLine($"race.Data.Checkpoints: {race.Data.Checkpoints.Dump()}");

            Checkpoints = race.Data.Checkpoints.ToDictionary(checkpoint => checkpoint.Id, checkpoint => race.Data.Begin);
            Console.WriteLine($"Checkpoints: {Checkpoints.Dump()}");

            if (RacerId is not null)
            {
                var racers = await _actionsRepository.GetResultsForActionRaceCategoryAsync(Guid.Parse(ActionId), Guid.Parse(RaceId), Guid.Parse(CategoryId), false);
                var racer = racers.Results.FirstOrDefault(racer => racer.Id == Guid.Parse(RacerId));
                
                if (racer != null)
                { 
                    Model.Id = racer.Id;
                    Model.FirstName = racer.FirstName;
                    Model.LastName = racer.LastName;
                    Model.Pets = racer.Pets;
                    Model.State = racer.State;
                    Model.Start = racer.Start;
                    Model.Finish = racer.Finish;
                    Model.Checkpoints = racer.Checkpoints;

                    foreach (var raceCheckpoint in race.Data.Checkpoints)
                    {
                        var existsCheckpoint = Model.Checkpoints.FirstOrDefault(checkpoint => checkpoint.Id == raceCheckpoint.Id);
                        if (existsCheckpoint == null)
                        {
                            Model.Checkpoints.Add(new ResultsModel.CheckpointDto()
                            {
                                Id = raceCheckpoint.Id,
                                Name = raceCheckpoint.Name,
                                IsCheckpointPassed = false
                            });
                        }
                        else
                        { 
                            existsCheckpoint.IsCheckpointPassed = true; 
                        }
                    }
                }
            }
        }
    }

    protected async Task OnFormValid()
    {
        await _actionsRepository.AddResultAsync(Guid.Parse(ActionId), Guid.Parse(RaceId), Guid.Parse(CategoryId), Model);

        // reload data from server after editation/adding process ...
        await _actionsRepository.GetResultsForActionRaceCategoryAsync(Guid.Parse(ActionId), Guid.Parse(RaceId), Guid.Parse(CategoryId), true);


        NavigationManager.NavigateTo($"/category/{ActionId}/{RaceId}/{CategoryId}");
    }

    protected async Task OnFormInvalid()
    {
        Console.WriteLine("OnFormInvalid");
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

    protected void CheckpointIsFilled(Guid checkpointId, Microsoft.AspNetCore.Components.Web.FocusEventArgs args)
    {
        Console.WriteLine($"CheckpointIsFilled with value: {checkpointId}");

        if (Checkpoints.ContainsKey(checkpointId))
        {
            if (Model.Checkpoints.FirstOrDefault(checkpoint => checkpoint.Id == checkpointId).IsCheckpointPassed == false)
            {
                Checkpoints[checkpointId] = DateTimeOffset.Now;
                
                Model.Checkpoints.RemoveAll(checkpoint => checkpoint.Id == checkpointId);
            }
            else
            { 
                var racerCheckpoint = Model.Checkpoints.FirstOrDefault(checkpoint => checkpoint.Id == checkpointId);

                if (racerCheckpoint != null)
                {
                    racerCheckpoint.Time = Checkpoints[checkpointId];
                }
                else
                {
                    Model.Checkpoints.Add(new ResultsModel.CheckpointDto()
                    {
                        Id = checkpointId,
                        Time = Checkpoints[checkpointId]
                    });
                }
            }
        }

        StateHasChanged();
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

    protected void CheckpointPassed(Guid checkpointId, Microsoft.AspNetCore.Components.ChangeEventArgs args)
    {
        StateHasChanged();
    }
}
