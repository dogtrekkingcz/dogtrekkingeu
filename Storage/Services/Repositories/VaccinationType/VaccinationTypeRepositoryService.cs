using MapsterMapper;
using Microsoft.Extensions.Logging;
using Storage.Entities.VaccinationTypes;
using Storage.Extensions;
using Storage.Interfaces;
using Storage.Models;

namespace Storage.Services.Repositories.VaccinationType;

internal class VaccinationTypeRepositoryService : IVaccinationTypeRepositoryService
{
    private readonly ILogger _logger;
    private readonly IMapper _mapper;
    private readonly IStorageService<VaccinationTypeRecord> _vaccinationTypeStorageService;

    public VaccinationTypeRepositoryService(ILogger<VaccinationTypeRepositoryService> logger, IMapper mapper, IStorageService<VaccinationTypeRecord> vaccinationTypeStorageService)
    {
        _logger = logger;
        _mapper = mapper;
        _vaccinationTypeStorageService = vaccinationTypeStorageService;
    }

    public async Task<AddVaccinationTypeInternalStorageResponse> AddAsync(AddVaccinationTypeInternalStorageRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"{nameof(AddAsync)} - request: '{request?.Dump()}'");

        var addRequest = _mapper.Map<VaccinationTypeRecord>(request);
        _logger.LogInformation($"{nameof(AddAsync)} - addRequest: '{addRequest?.Dump()}'");
        
        var addedVaccinationTypeRecord = await _vaccinationTypeStorageService.AddOrUpdateAsync(addRequest, cancellationToken);

        var response = new AddVaccinationTypeInternalStorageResponse
        {
            Id = addedVaccinationTypeRecord?.Id ?? ""
        };

        return response;
    }

    public async Task<GetAllVaccinationTypesInternalStorageResponse> GetAllAsync(CancellationToken cancellationToken)
    {
        var getAllVaccinationTypes = await _vaccinationTypeStorageService.GetAllAsync(cancellationToken);

        var vaccinationTypes = new List<GetAllVaccinationTypesInternalStorageResponse.VaccinationTypeDto>();
        foreach (var vaccinationType in getAllVaccinationTypes
            .Where(a => a.Id != null))
        {
            vaccinationTypes.Add(_mapper.Map<GetAllVaccinationTypesInternalStorageResponse.VaccinationTypeDto>(vaccinationType));
        }

        var response = new GetAllVaccinationTypesInternalStorageResponse
        {
            VaccinationTypes = vaccinationTypes
        };

        _logger.LogInformation($"{nameof(GetAllAsync)} - response: '{response?.Dump()}'");
        
        return response;
    }

    public async Task DeleteAsync(string id, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"{nameof(DeleteAsync)} - id: '{id}'");

        await _vaccinationTypeStorageService.DeleteAsync(id, cancellationToken);
    }
}