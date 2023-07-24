using DogsOnTrail.Interfaces.Actions.Entities.Results;
using DogsOnTrailGRPCService.Extensions;
using SharedCode.Entities;
using SharedCode.Extensions;
using Mapster;

namespace DogsOnTrailGRPCService.Services.Results;

internal static class ResultsServiceMapping
{
    internal static TypeAdapterConfig AddResultsMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<Protos.Results.AddResultRequest, AddResultRequest>();
        typeAdapterConfig.NewConfig<Protos.Results.AddResultRequest_FinalState, AddResultRequest.FinalState>();

        return typeAdapterConfig;
    }
}