using DogsOnTrail.Interfaces.Actions.Entities.Rights;
using DogsOnTrail.Interfaces.Actions.Services;
using MapsterMapper;
using Storage.Entities.ActionRights;
using Storage.Interfaces;

namespace DogsOnTrail.Actions.Services.Rights;

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
        var getAllRightsStorageRequest = new Storage.Entities.ActionRights.GetAllRightsInternalStorageRequest
        {
            UserId = request.UserId 
        };
        
        var allRights = await _actionRightsRepositoryService.GetAllRightsAsync(getAllRightsStorageRequest, cancellationToken);

        var response = new GetAllRightsResponse
        {
            Rights = _mapper.Map<List<GetAllRightsResponse.ActionRightsDto>>(allRights.Rights)
        };

        return response;
    }
}