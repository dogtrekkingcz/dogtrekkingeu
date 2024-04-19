using Mapster;
using static PetsOnTrailApp.Components.ResultsAdd.ResultAddModel;

namespace PetsOnTrailApp.Components.ResultsAdd;

public static class Mapping
{
    internal static TypeAdapterConfig AddResultsAddMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<ResultAddModel, Protos.Results.AddResultRequest>()
            .Ignore(dest => dest.ActionId)
            .Ignore(dest => dest.RaceId)
            .Ignore(dest => dest.CategoryId)
            .Ignore(dest => dest.Phone)
            .Ignore(dest => dest.Email);

        typeAdapterConfig.NewConfig<ResultAddModel.ResultState, Protos.Results.AddResultRequest_FinalState>()
            .MapWith(state => MapState(state));

        return typeAdapterConfig;
    }

    private static Protos.Results.AddResultRequest_FinalState MapState(ResultState state)
    {
        return state switch
        {
            ResultState.NotStarted => Protos.Results.AddResultRequest_FinalState.Dns,
            ResultState.Started => Protos.Results.AddResultRequest_FinalState.Started,
            ResultState.Finished => Protos.Results.AddResultRequest_FinalState.Finished,
            ResultState.DidNotFinished => Protos.Results.AddResultRequest_FinalState.Dnf,
            ResultState.Disqualified => Protos.Results.AddResultRequest_FinalState.Dsq,
            _ => Protos.Results.AddResultRequest_FinalState.NotSpecified
        };
    }
}
