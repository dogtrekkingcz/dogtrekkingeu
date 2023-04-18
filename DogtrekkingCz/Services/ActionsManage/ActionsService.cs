using DogtrekkingCz.Interfaces.Actions.Entities.Actions;
using DogtrekkingCz.Interfaces.Actions.Services;
using DogtrekkingCzShared.Entities;
using DogtrekkingCzShared.JwtToken;
using MapsterMapper;
using Storage.Entities.Actions;
using Storage.Interfaces;

namespace DogtrekkingCz.Actions.Services.ActionsManage
{
    internal class ActionsService : IActionsService
    {
        private readonly IMapper _mapper;
        private readonly IActionsRepositoryService _actionsRepositoryService;
        private readonly IActionRightsRepositoryService _actionRightsRepositoryService;
        private readonly IJwtTokenService _jwtTokenService;

        public ActionsService(IMapper mapper, 
            IActionsRepositoryService actionsRepositoryService, 
            IActionRightsRepositoryService actionRightsRepositoryService,
            IJwtTokenService jwtTokenService)
        {
            _mapper = mapper;
            _actionsRepositoryService = actionsRepositoryService;
            _actionRightsRepositoryService = actionRightsRepositoryService;
            _jwtTokenService = jwtTokenService;
        }

        public async Task<CreateActionResponse> CreateActionAsync(CreateActionRequest request, CancellationToken cancellationToken)
        {
            var addActionRequest = _mapper.Map<CreateActionInternalStorageRequest>(request);
            addActionRequest.Id = Guid.NewGuid().ToString();

            var result = await _actionsRepositoryService.AddActionAsync(addActionRequest, cancellationToken);

            await _actionRightsRepositoryService.AddActionRightsAsync(new Storage.Entities.ActionRights.AddActionRightsRequest
            {
                ActionId = result.Id,
                UserId = _jwtTokenService.GetUserId(),
                Roles = new List<string> { AuthorizationRoleDto.RoleType.Owner.ToString() }
            }, cancellationToken);

            var response = _mapper.Map<CreateActionResponse>(result);

            return response;
        }

        public async Task<UpdateActionResponse> UpdateActionAsync(UpdateActionRequest request, CancellationToken cancellationToken)
        {
            var updateActionRequest = _mapper.Map<UpdateActionInternalStorageRequest>(request);
        
            var result = await _actionsRepositoryService.UpdateActionAsync(updateActionRequest, cancellationToken);

            var response = _mapper.Map<UpdateActionResponse>(result);

            return response;
        }
        
        public async Task<GetActionDetailResponse> GetActionDetailAsync(GetActionDetailRequest request, CancellationToken cancellationToken)
        {
            var actionDetail = await _actionsRepositoryService.GetActionAsync(new GetActionInternalStorageRequest
            {
                Id = request.Id
            }, cancellationToken);

            return new GetActionDetailResponse();
        }

        public async Task<GetAllActionsResponse> GetAllActionsAsync(GetAllActionsRequest request, CancellationToken cancellationToken)
        {
            var allActions = await _actionsRepositoryService.GetAllActionsAsync(cancellationToken);

            var response = _mapper.Map<GetAllActionsResponse>(allActions);

            return response;
        }

        public async Task<GetAllActionsWithDetailsResponse> GetAllActionsWithDetailsAsync(GetAllActionsWithDetailsRequest request, CancellationToken cancellationToken)
        {
            var allActions = await _actionsRepositoryService.GetAllActionsAsync(cancellationToken);

            var response = _mapper.Map<GetAllActionsWithDetailsResponse>(allActions.Actions);

            return response;
        }

        public async Task<GetActionResponse> GetActionAsync(GetActionRequest request, CancellationToken cancellationToken)
        {
            var getActionRequest = _mapper.Map<GetActionInternalStorageRequest>(request);

            var result = await _actionsRepositoryService.GetActionAsync(getActionRequest, cancellationToken);

            var response = _mapper.Map<GetActionResponse>(result);

            return response;
        }

        public async Task DeleteActionAsync(DeleteActionRequest request, CancellationToken cancellationToken)
        {
            var deleteActionRequest = _mapper.Map<DeleteActionInternalStorageRequest>(request);

            await _actionsRepositoryService.DeleteActionAsync(deleteActionRequest, cancellationToken);
        }
    }
}
