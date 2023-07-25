using DogsOnTrail.Interfaces.Actions.Entities.Results;
using Mapster;

namespace API.GRPCService.Services.Results;

internal static class ResultsServiceMapping
{
    internal static TypeAdapterConfig AddResultsMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<Protos.Results.AddResultRequest, AddResultRequest>();
        typeAdapterConfig.NewConfig<Protos.Results.AddResultRequest_FinalState, AddResultRequest.FinalState>();

        return typeAdapterConfig;
    }
}