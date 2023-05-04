using DogtrekkingCz.Interfaces.Actions.Entities.Results;
using DogtrekkingCz.Interfaces.Actions.Services;
using Google.Protobuf.Collections;
using Grpc.Core;
using MapsterMapper;
using Protos.Results;
using AddResultRequest = DogtrekkingCz.Interfaces.Actions.Entities.Results.AddResultRequest;
using GetRacesForActionRequest = DogtrekkingCz.Interfaces.Actions.Entities.Results.GetRacesForActionRequest;

namespace DogtrekkingCzGRPCService.Services.Results;

internal class ResultsService : Protos.Results.Results.ResultsBase
{
    private readonly ILogger _logger;
    private readonly IMapper _mapper;
    private readonly IResultsService _resultsService;

    public ResultsService(ILogger<ResultsService> logger, IMapper mapper, IResultsService resultsService)
    {
        _logger = logger;
        _mapper = mapper;
        _resultsService = resultsService;
    }

    public async override Task<Protos.Results.AddResultResponse> addResult(Protos.Results.AddResultRequest request, ServerCallContext context)
    {
        var addResultRequest = _mapper.Map<AddResultRequest>(request);
        
        await _resultsService.AddResultAsync(addResultRequest, context.CancellationToken);

        return new Protos.Results.AddResultResponse();
    }

    public async override Task<Protos.Results.GetRacesForActionResponse> getRacesForAction(Protos.Results.GetRacesForActionRequest request, ServerCallContext context)
    {
        var racesResponse = await _resultsService.GetRacesForAction(new GetRacesForActionRequest { ActionId = Guid.Parse(request.ActionId) }, context.CancellationToken);

        var result = new Protos.Results.GetRacesForActionResponse();
        result.Races.AddRange(_mapper.Map<RepeatedField<Protos.Shared.RaceDetail>>(racesResponse));

        return result;
    }
}