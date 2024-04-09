using API.WebApiService.Entities;
using PetsOnTrail.Interfaces.Actions.Services;
using MapsterMapper;
using Mediator;

namespace API.WebApiService.RequestHandlers.Activities;

public sealed class UpdateActivityHandler : IRequestHandler<UpdateActivityRequest, UpdateActivityResponse>
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public UpdateActivityHandler(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    public async ValueTask<UpdateActivityResponse> Handle(UpdateActivityRequest request, CancellationToken cancellationToken)
    {
        using (var scope = _serviceScopeFactory.CreateScope())
        {
            var mapper = scope.ServiceProvider.GetRequiredService<IMapper>();

            var activitiesService = scope.ServiceProvider.GetRequiredService<IActivitiesService>();

            var updateActivitiesRequest =
                mapper.Map<PetsOnTrail.Interfaces.Actions.Entities.Activities.UpdateActivityRequest>(request);

            var updatedActivity = await activitiesService.UpdateActivityAsync(updateActivitiesRequest, cancellationToken);

            var entry = mapper.Map<UpdateActivityResponse>(updatedActivity);
            
            return new ValueTask<UpdateActivityResponse>(entry).Result;
        }
    }
}
