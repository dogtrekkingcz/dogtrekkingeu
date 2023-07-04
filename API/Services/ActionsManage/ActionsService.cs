using DogsOnTrail.Interfaces.Actions.Entities.Actions;
using DogsOnTrail.Interfaces.Actions.Services;
using SharedCode.Entities;
using SharedCode.JwtToken;
using MapsterMapper;
using Storage.Entities.Actions;
using Storage.Interfaces;

namespace DogsOnTrail.Actions.Services.ActionsManage
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

            foreach (var race in addActionRequest.Races)
            {
                if (race.Id == default)
                    race.Id = Guid.NewGuid();

                foreach (var category in race.Categories)
                {
                    if (category.Id == default)
                        category.Id = Guid.NewGuid();
                }
            }

            var result = await _actionsRepositoryService.AddActionAsync(addActionRequest, cancellationToken);

            await _actionRightsRepositoryService.AddActionRightsAsync(new Storage.Entities.ActionRights.AddActionRightsRequest
            {
                Id = Guid.NewGuid().ToString(),
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

        public async Task<GetActionEntrySettingsResponse> GetActionEntrySettings(GetActionEntrySettingsRequest request, CancellationToken cancellationToken)
        {
            var getActionRequest = _mapper.Map<GetActionInternalStorageRequest>(request);

            var result = await _actionsRepositoryService.GetActionAsync(getActionRequest, cancellationToken);

            var response = new GetActionEntrySettingsResponse
            {
                Id = result.Id,
                Name = result.Name,
                Races = result.Races.Select(r => 
                        new GetActionEntrySettingsResponse.RaceDto
                        {
                            Id = r.Id.ToString(),
                            Name = r.Name,
                            Start = r.Begin,
                            Limits = new ActionSettingsDto.RaceLimits
                            {
                                MinimalAgeOfRacerInDayes = r.Limits?.MinimalAgeOfRacerInDayes ?? 0,
                                MinimalAgeOfTheDogInDayes = r.Limits?.MinimalAgeOfTheDogInDayes ?? 0
                            }
                        })
                        .ToList(),
                Categories = result.Races.SelectMany(r => r.Categories.Select(ctg =>
                    new GetActionEntrySettingsResponse.CategoryDto
                    {
                        Id = ctg.Id.ToString(),
                        Name = ctg.Name,
                        RaceId = r.Id.ToString()
                    }))
                    .ToList()
            };

            return response;
        }

        public async Task<GetSelectedActionsResponse> GetSelectedActionsAsync(GetSelectedActionsRequest request, CancellationToken cancellationToken)
        {
            var getSelectedActionsRequest = _mapper.Map<GetSelectedActionsInternalStorageRequest>(request);
            
            var result = await _actionsRepositoryService.GetSelectedActionsAsync(getSelectedActionsRequest, cancellationToken);
            
            return _mapper.Map<GetSelectedActionsResponse>(result.Actions);
        }
    }
}
