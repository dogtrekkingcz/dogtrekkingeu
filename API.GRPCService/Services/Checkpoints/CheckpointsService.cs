using API.GRPCService.Extensions;
using DogsOnTrail.Interfaces.Actions.Entities.Checkpoints;
using DogsOnTrail.Interfaces.Actions.Services;
using Grpc.Core;
using MapsterMapper;

namespace API.GRPCService.Services.Checkpoints;

public class CheckpointsService : Protos.Checkpoints.Checkpoints.CheckpointsBase
{
    private readonly ILogger _logger;
    private readonly IMapper _mapper;
    private readonly ICheckpointsService _checkpointsService;

    public CheckpointsService(ILogger<CheckpointsService> logger, IMapper mapper, ICheckpointsService checkpointsService)
    {
        _logger = logger;
        _mapper = mapper;
        _checkpointsService = checkpointsService;
    }
    
    public async override Task<Protos.Checkpoints.AddCheckpoint.AddCheckpointResponse> addCheckpoint(Protos.Checkpoints.AddCheckpoint.AddCheckpointRequest request, ServerCallContext context)
    {
        var apiRequest = _mapper.Map<AddCheckpointItemRequest>(request);

        var response = await _checkpointsService.AddAsync(apiRequest, context.CancellationToken);
        
        return _mapper.Map<Protos.Checkpoints.AddCheckpoint.AddCheckpointResponse>(response);
    }

    public async override Task<Protos.Checkpoints.GetCheckpoints.GetCheckpointsResponse> getCheckpoints(Protos.Checkpoints.GetCheckpoints.GetCheckpointsRequest request, ServerCallContext context)
    {
        var apiRequest = _mapper.Map<GetCheckpointItemsRequest>(request);

        var response = await _checkpointsService.GetAsync(apiRequest, context.CancellationToken);

        Console.WriteLine(response?.Dump());
        
        return _mapper.Map<Protos.Checkpoints.GetCheckpoints.GetCheckpointsResponse>(response);
    }
    
}