using MapsterMapper;
using Microsoft.Extensions.Logging;
using Storage.Entities.PetTypes;
using Storage.Extensions;
using Storage.Interfaces;
using Storage.Models;

namespace Storage.Services.Repositories.PetType;

internal class PetTypeRepositoryService : IPetTypeRepositoryService
{
    private readonly ILogger _logger;
    private readonly IMapper _mapper;
    private readonly IStorageService<PetTypeRecord> _petTypeStorageService;

    public PetTypeRepositoryService(ILogger<PetTypeRepositoryService> logger, IMapper mapper, IStorageService<PetTypeRecord> petTypeStorageService)
    {
        _logger = logger;
        _mapper = mapper;
        _petTypeStorageService = petTypeStorageService;
    }

    public async Task AddAsync(AddPetTypeInternalStorageRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"{nameof(AddAsync)} - request: '{request?.Dump()}'");

        var addRequest = _mapper.Map<PetTypeRecord>(request);
        _logger.LogInformation($"{nameof(AddAsync)} - addRequest: '{addRequest?.Dump()}'");
        
        var addedVaccinationTypeRecord = await _petTypeStorageService.AddOrUpdateAsync(addRequest, cancellationToken);
    }

    public async Task<GetPetTypesInternalStorageResponse> GetAllAsync(CancellationToken cancellationToken)
    {
        var getPetTypes = await _petTypeStorageService.GetAllAsync(cancellationToken);

        var petTypes = new List<GetPetTypesInternalStorageResponse.PetTypeDto>();
        foreach (var vaccinationType in getPetTypes
            .Where(a => a.Id != null))
        {
            petTypes.Add(_mapper.Map<GetPetTypesInternalStorageResponse.PetTypeDto>(vaccinationType));
        }

        var response = new GetPetTypesInternalStorageResponse
        {
            PetTypes = petTypes
        };
        
        return response;
    }

    public async Task DeleteAsync(string id, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"{nameof(DeleteAsync)} - id: '{id}'");

        await _petTypeStorageService.DeleteAsync(id, cancellationToken);
    }
}