using DogsOnTrail.Interfaces.Actions.Entities.Activities;
using DogsOnTrail.Interfaces.Actions.Services;
using Grpc.Core;
using MapsterMapper;

namespace API.GRPCService.Services.Activities;

public class ActivitiesService : Protos.Activities.Activities.ActivitiesBase
{
    private readonly ILogger _logger;
    private readonly IMapper _mapper;
    private readonly IActivitiesService _activitiesService;

    public ActivitiesService(ILogger<ActivitiesService> logger, IMapper mapper, IActivitiesService activitiesService)
    {
        _logger = logger;
        _mapper = mapper;
        _activitiesService = activitiesService;
    }
    
    public async override Task<Protos.Activities.CreateActivity.CreateActivityResponse> createActivity(Protos.Activities.CreateActivity.CreateActivityRequest request, ServerCallContext context)
    {
        var apiRequest = _mapper.Map<CreateActivityRequest>(request);

        var response = await _activitiesService.CreateActivityAsync(apiRequest, context.CancellationToken);
        
        return _mapper.Map<Protos.Activities.CreateActivity.CreateActivityResponse>(response);
    }

    public async override Task<Protos.Activities.AddPoint.AddPointResponse> addPoint(Protos.Activities.AddPoint.AddPointRequest request, ServerCallContext context)
    {
        var apiRequest = _mapper.Map<AddPointRequest>(request);

        var response = await _activitiesService.AddPointAsync(apiRequest, context.CancellationToken);

        return _mapper.Map<Protos.Activities.AddPoint.AddPointResponse>(response);
    }

    public async override Task<Protos.Activities.GetMyActivities.GetMyActivitiesResponse> getMyActivities(Protos.Activities.GetMyActivities.GetMyActivitiesRequest request, ServerCallContext context)
    {
        var apiRequest = _mapper.Map<GetMyActivitiesRequest>(request);

        var result = await _activitiesService.GetMyActivitiesAsync(apiRequest, context.CancellationToken);

        return _mapper.Map<Protos.Activities.GetMyActivities.GetMyActivitiesResponse>(result);
    }
}