using API.GRPCService.Extensions;
using PetsOnTrail.Interfaces.Actions.Entities.Activities;
using PetsOnTrail.Interfaces.Actions.Services;
using Grpc.Core;
using MapsterMapper;
using GetMyActivitiesRequest = PetsOnTrail.Interfaces.Actions.Entities.Activities.GetMyActivitiesRequest;
using PetsOnTrail.Interfaces.Actions.Entities.JwtToken;
using System.Runtime.CompilerServices;
using Protos.Activities;

namespace API.GRPCService.Services.Activities;

public class ActivitiesService : Protos.Activities.Activities.ActivitiesBase
{
    private readonly ILogger _logger;
    private readonly IMapper _mapper;
    private readonly IActivitiesService _activitiesService;
    private readonly IJwtTokenService _jwtTokenService;

    public ActivitiesService(ILogger<ActivitiesService> logger, IMapper mapper, IActivitiesService activitiesService, IJwtTokenService jwtTokenService)
    {
        _logger = logger;
        _mapper = mapper;
        _activitiesService = activitiesService;
        _jwtTokenService = jwtTokenService;
    }
    
    public async override Task<Protos.Activities.CreateActivity.CreateActivityResponse> createActivity(Protos.Activities.CreateActivity.CreateActivityRequest request, ServerCallContext context)
    {
        _logger.LogInformation($"CreateActivity: {request.Dump()}");

        var apiRequest = _mapper.Map<CreateActivityRequest>(request)with
        {
            UserId = _jwtTokenService.GetUserId()
        };

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
        
        Console.WriteLine(result.Dump());

        return new Protos.Activities.GetMyActivities.GetMyActivitiesResponse
        {
            Activities =
            {
                result.Activities
                    .Select(activity => _mapper.Map<Protos.Activities.GetMyActivities.ActivityDto>(activity))
                    .ToList()
            }
        };
    }

    public async override Task<Protos.Activities.GetActivityByUserIdAndActivityId.GetActivityByUserIdAndActivityIdResponse> getActivityByUserIdAndActivityId(Protos.Activities.UserIdAndActivityId request, ServerCallContext context)
    {
        var result = await _activitiesService.GetActivityByUserIdAndActivityIdAsync(Guid.Parse(request.UserId), Guid.Parse(request.ActivityId), context.CancellationToken);

        _logger.LogInformation($"GetActivityByUserIdAndActivityId: {result.Dump()}");

        var response = _mapper.Map<Protos.Activities.GetActivityByUserIdAndActivityId.GetActivityByUserIdAndActivityIdResponse>(result);

        _logger.LogInformation($"GetActivityByUserIdAndActivityId: {response.Dump()}");

        return response;
    }

    public async override Task<Protos.Activities.GetActivitiesByUserId.GetActivitiesByUserIdResponse> getActivitiesByUserId(UserIdRequest userId, ServerCallContext context)
    {
        var result = await _activitiesService.GetActivitiesByUserIdAsync(Guid.Parse(userId.UserId), context.CancellationToken);

        return new Protos.Activities.GetActivitiesByUserId.GetActivitiesByUserIdResponse
        {
            Activities =
            {
                result.Activities
                    .Select(activity => _mapper.Map<Protos.Activities.GetActivitiesByUserId.ActivityDto>(activity))
                    .ToList()
            }
        };
    }

    public async override Task<Protos.Activities.GetActivities.GetActivitiesResponse> getActivities(Google.Protobuf.WellKnownTypes.Empty _, ServerCallContext context)
    {
        var result = await _activitiesService.GetActivitiesAsync(context.CancellationToken);

        return new Protos.Activities.GetActivities.GetActivitiesResponse
        {
            Activities =
            {
                result.Activities
                    .Select(activity => _mapper.Map<Protos.Activities.GetActivities.ActivityDto>(activity))
                    .ToList()
            }
        };
    }

    public async override Task<Protos.Activities.GetActivityTypes.GetActivityTypesResponse> getActivityTypes(Google.Protobuf.WellKnownTypes.Empty _, ServerCallContext context)
    {
        var result = await _activitiesService.GetActivityTypesAsync(context.CancellationToken);

        return _mapper.Map<Protos.Activities.GetActivityTypes.GetActivityTypesResponse>(result);
    }
}