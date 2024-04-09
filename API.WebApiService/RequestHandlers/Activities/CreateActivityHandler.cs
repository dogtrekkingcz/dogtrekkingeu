using API.WebApiService.Entities;
using PetsOnTrail.Interfaces.Actions.Services;
using MapsterMapper;
using Mediator;

namespace API.WebApiService.RequestHandlers.Activities;

public sealed class CreateActivityHandler : IRequestHandler<CreateActivityRequest, CreateActivityResponse>
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public CreateActivityHandler(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    public async ValueTask<CreateActivityResponse> Handle(CreateActivityRequest request, CancellationToken cancellationToken)
    {
        using (var scope = _serviceScopeFactory.CreateScope())
        {
            var mapper = scope.ServiceProvider.GetRequiredService<IMapper>();

            var activitiesService = scope.ServiceProvider.GetRequiredService<IActivitiesService>();

            var createActivitiesRequest =
                mapper.Map<PetsOnTrail.Interfaces.Actions.Entities.Activities.CreateActivityRequest>(request);

            var newEntry = await activitiesService.CreateActivityAsync(createActivitiesRequest, cancellationToken);

            var entry = mapper.Map<CreateActivityResponse>(newEntry);
            
            return new ValueTask<CreateActivityResponse>(entry).Result;
        }
    }
}
