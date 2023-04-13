using DogtrekkingCz.Interfaces.Actions.Entities;
using DogtrekkingCz.Interfaces.Actions.Services;
using Storage.Entities.Actions;
using Storage.Interfaces;

namespace DogtrekkingCz.Actions
{
    internal class ActionsService : IActionsService
    {
        private readonly IActionsRepositoryService _actionsRepositoryService;

        public ActionsService(IActionsRepositoryService actionsRepositoryService)
        {
            _actionsRepositoryService = actionsRepositoryService;
        }

        public async Task<ActionDetailResponse> GetActionDetail(ActionDetailRequest request, CancellationToken cancellationToken)
        {
            var actionDetail = await _actionsRepositoryService.GetActionAsync(new GetActionRequest
            {
                Id = request.Id
            }, cancellationToken);

            return new ActionDetailResponse();
        }
    }
}
