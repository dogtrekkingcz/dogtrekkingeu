using Microsoft.AspNetCore.Components;
using Protos.Results;
using System.Text.RegularExpressions;
using static Protos.Results.Results;
using MapsterMapper;

namespace PetsOnTrailApp.Components.ResultsAdd;

public class ResultsAddBase : ComponentBase
{
    [Parameter] 
    public string ActionId { get; set; }
    [Parameter] 
    public Guid RaceId { get; set; }
    [Parameter] 
    public Guid CategoryId { get; set; }
    [Parameter] 
    public DateTimeOffset RaceBegin { get; set; }
    [Parameter] 
    public DateTimeOffset RaceEnd { get; set; }
    [Parameter] 
    public EventCallback OnResultAddedCallback { get; set; }

    [Inject]
    private ResultsClient _resultsClient { get; set; }

    [Inject]
    private IMapper _mapper { get; set; }


    protected ResultAddModel Model = new();

    protected string WholeTime { get; set; } = string.Empty;
    protected string _pets { get; set; } = string.Empty;

    protected DateTimeOffset Start { get; set; }
    protected DateTimeOffset Finish { get; set; }

    protected ResultAddModel.ResultState State { get; set; } = ResultAddModel.ResultState.NotValid;

    protected bool IsStartShown => (new List<ResultAddModel.ResultState>()
                                    {
                                        ResultAddModel.ResultState.Started,
                                        ResultAddModel.ResultState.Finished,
                                        ResultAddModel.ResultState.DidNotFinished,
                                        ResultAddModel.ResultState.Disqualified
                                    }).Contains(Model.State);

    protected bool IsFinishShown => (new List<ResultAddModel.ResultState>()
    {
        ResultAddModel.ResultState.Finished,
    }).Contains(Model.State);

    protected override void OnInitialized()
    {
        Start = RaceBegin;
        Finish = RaceEnd;
    }

    protected async Task OnFormValid()
    {
        var request = _mapper.Map<AddResultRequest>(Model) with
        {
            ActionId = ActionId,
            RaceId = RaceId,
            CategoryId = CategoryId
        };
        await _resultsClient.addResultAsync(request);

        await OnResultAddedCallback.InvokeAsync((ActionId, RaceId, CategoryId, Model));
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

    protected void RaceStateChanged(ResultAddModel.ResultState state)
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

        Model.Start = RaceBegin;
        Model.Finish = RaceBegin.AddHours(hours).AddMinutes(minutes).AddSeconds(seconds);

        StateHasChanged();
    }
}
