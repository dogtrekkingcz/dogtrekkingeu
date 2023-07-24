using SharedCode.Extensions;
using Mapster;
using SharedCode.Entities;

namespace DogsOnTrailApp.Models;

internal static class ResultsModelMapping
{
    internal static TypeAdapterConfig AddResultsModelMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<AddNewResult_FinalState, Protos.Results.AddResultRequest_FinalState>();
        
        return typeAdapterConfig;
    }
}