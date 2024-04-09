using PetsOnTrail.Interfaces.Actions.Entities.Results;
using PetsOnTrail.Interfaces.Actions.Services;
using Grpc.Core;
using MapsterMapper;

namespace API.GRPCService.Services.Results;

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
}