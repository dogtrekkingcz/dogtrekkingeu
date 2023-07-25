using API.WebApiService.Entities;
using DogsOnTrail.Interfaces.Actions.Services;
using MapsterMapper;
using Mediator;

namespace API.WebApiService.RequestHandlers.Actions
{
    public sealed class GetActionDetailsHandler : IRequestHandler<ActionDetailRequest, ActionDetailResponse>
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public GetActionDetailsHandler(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async ValueTask<ActionDetailResponse> Handle(ActionDetailRequest request, CancellationToken cancellationToken)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var mapper = scope.ServiceProvider.GetRequiredService<IMapper>();

                var actionsService = scope.ServiceProvider.GetRequiredService<IActionsService>();
                
                var action = await actionsService.GetActionDetailAsync(request.Id, cancellationToken);

                return new ValueTask<ActionDetailResponse>(new ActionDetailResponse(Guid.NewGuid())).Result;
            }
        }
    }
}
