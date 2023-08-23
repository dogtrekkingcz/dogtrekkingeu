using DogsOnTrail.Interfaces.Actions.Entities.Results;
using DogsOnTrail.Interfaces.Actions.Services;
using MapsterMapper;
using Storage.Entities.Actions;
using Storage.Interfaces;

namespace DogsOnTrail.Actions.Services.ResultsManage;

 internal class ResultsService : IResultsService
{
    private readonly IMapper _mapper;
    private readonly IActionsRepositoryService _actionsRepositoryService;
    private readonly ICurrentUserIdService _currentUserIdService;

    public ResultsService(IMapper mapper, IActionsRepositoryService actionsRepositoryService, ICurrentUserIdService currentUserIdService)
    {
        _mapper = mapper;
        _actionsRepositoryService = actionsRepositoryService;
        _currentUserIdService = currentUserIdService;
    }
    
    public async Task<AddResultResponse> AddResultAsync(AddResultRequest request, CancellationToken cancellationToken)
    {
        var addResultRequest = _mapper.Map<AddResultInternalStorageRequest>(request)
            with
            {
                UserId = _currentUserIdService.GetUserId()
            };
        var response = await _actionsRepositoryService.AddResultAsync(addResultRequest, cancellationToken);

        return _mapper.Map<AddResultResponse>(response);
    }

    public async Task<AcceptResultResponse> AcceptResultAsync(AcceptResultRequest request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(new AcceptResultResponse());
    }
}