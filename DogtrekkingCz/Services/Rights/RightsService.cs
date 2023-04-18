using DogtrekkingCz.Interfaces.Actions.Entities.Rights;
using DogtrekkingCz.Interfaces.Actions.Services;
using DogtrekkingCzShared.Entities;
using MapsterMapper;
using Storage.Interfaces;

namespace DogtrekkingCz.Actions.Services.Rights;

internal sealed class RightsService : IRightsService
{
    private readonly IMapper _mapper;
    private readonly IActionRightsRepositoryService _actionRightsRepositoryService;
    
    public RightsService(IMapper mapper, IActionRightsRepositoryService actionRightsRepositoryService)
    {
        _mapper = mapper;
        _actionRightsRepositoryService = actionRightsRepositoryService;
    }
    
    public async Task<GetAllRightsResponse> GetAllRightsAsync(GetAllRightsRequest request, CancellationToken cancellationToken)
    {
        var getAllRightsStorageRequest = new Storage.Entities.ActionRights.GetAllRightsRequest
        {
            UserId = request.UserId 
        };
        
        var allRights = await _actionRightsRepositoryService.GetAllRightsAsync(getAllRightsStorageRequest, cancellationToken);

        var response = new GetAllRightsResponse
        {
            Rights = _mapper.Map<List<ActionRightsDto>>(allRights.Rights)
        };

        return response;
    }
}