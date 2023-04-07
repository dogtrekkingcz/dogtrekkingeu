using DogtrekkingCz.Interfaces.Entities;
using DogtrekkingCz.Interfaces.Services;
using Storage.Entities.Actions;
using Storage.Interfaces;

namespace DogtrekkingCz
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
            });

            return new ActionDetailResponse();
        }
    }
}
