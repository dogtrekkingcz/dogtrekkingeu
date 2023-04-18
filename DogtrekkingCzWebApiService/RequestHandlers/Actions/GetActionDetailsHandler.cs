using DogtrekkingCz.Interfaces.Actions.Entities.Actions;
using DogtrekkingCz.Interfaces.Actions.Services;
using DogtrekkingCzWebApiService.Entities;
using MapsterMapper;
using Mediator;

namespace DogtrekkingCzWebApiService.RequestHandlers.Actions
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

                var actionDetailRequest = mapper.Map<GetActionDetailRequest>(request);

                var action = await actionsService.GetActionDetailAsync(actionDetailRequest, cancellationToken);

                return new ValueTask<ActionDetailResponse>(new ActionDetailResponse(Guid.NewGuid())).Result;
            }
        }
    }
}
