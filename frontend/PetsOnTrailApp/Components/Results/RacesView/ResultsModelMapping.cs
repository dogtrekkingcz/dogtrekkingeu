using Mapster;
using PetsOnTrailApp.Components.ResultsAdd;
using static Microsoft.Maui.ApplicationModel.Permissions;
using static PetsOnTrailApp.Components.ResultsAdd.ResultAddModel;

namespace PetsOnTrailApp.Components.Results.Results;

internal static class ResultsModelMapping
{
    internal static TypeAdapterConfig AddResultsModelMapping(this TypeAdapterConfig typeAdapterConfig)
    {


        typeAdapterConfig.NewConfig<ResultModel.FinalState, Protos.Results.AddResultRequest_FinalState>();

        typeAdapterConfig.NewConfig<ActionModel.RacerDto, ActionResultsModel.RacerResultDto>();
        typeAdapterConfig.NewConfig<ActionModel.RaceState, ActionResultsModel.RaceState>();
        typeAdapterConfig.NewConfig<ActionModel.PetDto, ActionResultsModel.PetDto>();

        return typeAdapterConfig;
    }
}