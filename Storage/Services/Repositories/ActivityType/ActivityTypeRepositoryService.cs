using MapsterMapper;
using Microsoft.Extensions.Logging;
using Storage.Entities.ActivityTypes;
using Storage.Extensions;
using Storage.Interfaces;
using Storage.Models;

namespace Storage.Services.Repositories.Actions;

internal class ActivityTypeRepositoryService : IActivityTypeRepositoryService
{
    private readonly ILogger _logger;
    private readonly IMapper _mapper;
    private readonly IStorageService<ActivityTypeRecord> _activityTypeStorageService;

    public ActivityTypeRepositoryService(ILogger<ActivityTypeRepositoryService> logger, IMapper mapper, IStorageService<ActivityTypeRecord> activityTypeStorageService)
    {
        _logger = logger;
        _mapper = mapper;
        _activityTypeStorageService = activityTypeStorageService;
    }

    public async Task<AddActivityTypeInternalStorageResponse> AddAsync(AddActivityTypeInternalStorageRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"{nameof(AddAsync)} - request: '{request?.Dump()}'");

        var addRequest = _mapper.Map<ActivityTypeRecord>(request);
        _logger.LogInformation($"{nameof(AddAsync)} - addRequest: '{addRequest?.Dump()}'");
        
        var addedActivityTypeRecord = await _activityTypeStorageService.AddOrUpdateAsync(addRequest, cancellationToken);

        var response = new AddActivityTypeInternalStorageResponse
        {
            Id = addedActivityTypeRecord?.Id ?? Guid.Empty
        };

        return response;
    }

    public async Task<GetAllActivityTypesInternalStorageResponse> GetAllAsync(CancellationToken cancellationToken)
    {
        var getAllActivityTypes = await _activityTypeStorageService.GetAllAsync(cancellationToken);

        var activityTypes = new List<GetAllActivityTypesInternalStorageResponse.ActivityTypeDto>();
        foreach (var activityType in getAllActivityTypes
            .Where(a => a.Id != null))
        {
            activityTypes.Add(_mapper.Map<GetAllActivityTypesInternalStorageResponse.ActivityTypeDto>(activityType));
        }

        var response = new GetAllActivityTypesInternalStorageResponse
        {
            ActivityTypes = activityTypes
        };

        _logger.LogInformation($"{nameof(GetAllAsync)} - response: '{response?.Dump()}'");
        
        return response;
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"{nameof(DeleteAsync)} - id: '{id}'");

        await _activityTypeStorageService.DeleteAsync(id, cancellationToken);
    }
}