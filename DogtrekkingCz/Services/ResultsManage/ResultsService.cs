using DogtrekkingCz.Interfaces.Actions.Entities.Results;
using DogtrekkingCz.Interfaces.Actions.Services;
using DogtrekkingCzShared.Entities;
using MapsterMapper;
using Storage.Entities.Actions;
using Storage.Interfaces;

namespace DogtrekkingCz.Actions.Services.ResultsManage;

 internal class ResultsService : IResultsService
{
    private readonly IMapper _mapper;
    private readonly IActionsRepositoryService _actionsRepositoryService;

    public ResultsService(IMapper mapper, IActionsRepositoryService actionsRepositoryService)
    {
        _mapper = mapper;
        _actionsRepositoryService = actionsRepositoryService;
    }
    
    public async Task<AddResultResponse> AddResultAsync(AddResultRequest request, CancellationToken cancellationToken)
    {
        var addResultRequest = _mapper.Map<AddResultInternalStorageRequest>(request);
        var response = await _actionsRepositoryService.AddResultAsync(addResultRequest, cancellationToken);

        return _mapper.Map<AddResultResponse>(response);
    }

    public async Task<List<RaceDto>> GetRacesForAction(GetRacesForActionRequest request, CancellationToken cancellationToken)
    {
        var action = await _actionsRepositoryService.GetActionAsync(new GetActionInternalStorageRequest { Id = request.ActionId }, cancellationToken);

        return action.Races.ToList();
    }

    public async Task<AcceptResultResponse> AcceptResultAsync(AcceptResultRequest request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(new AcceptResultResponse());
    }
}