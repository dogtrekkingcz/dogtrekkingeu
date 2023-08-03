using Mapster;

namespace PetsOnTrailApp.Models;

internal static class ResultsModelMapping
{
    internal static TypeAdapterConfig AddResultsModelMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<ResultModel, Protos.Results.AddResultRequest>();
        typeAdapterConfig.NewConfig<ResultModel.FinalState, Protos.Results.AddResultRequest_FinalState>();
        
        return typeAdapterConfig;
    }
}