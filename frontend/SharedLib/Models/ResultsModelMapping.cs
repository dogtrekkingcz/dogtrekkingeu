using Mapster;

namespace SharedLib.Models;

internal static class ResultsModelMapping
{
    internal static TypeAdapterConfig AddResultsModelMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<ResultModel, Protos.Results.AddResultRequest>();
        typeAdapterConfig.NewConfig<ResultModel.FinalState, Protos.Results.AddResultRequest_FinalState>();

        typeAdapterConfig.NewConfig<ActionModel.RacerDto, ActionResultsModel.RacerResultDto>();
        typeAdapterConfig.NewConfig<ActionModel.RaceState, ActionResultsModel.RaceState>();
        typeAdapterConfig.NewConfig<ActionModel.PetDto, ActionResultsModel.PetDto>();

        return typeAdapterConfig;
    }
}